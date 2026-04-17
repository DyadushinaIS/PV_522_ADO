using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DBtools
{
	public class Connector
	{
		SqlConnection connection;
		public Connector(string connection_string)
		{
			connection = new SqlConnection(connection_string);
			Console.WriteLine(connection.ConnectionString);
		}
		public DataTable Load(string cmd)
		{
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();
			table.Load(reader);
			reader.Close();
			connection.Close();
			return table;
		}
		public DataTable Select(string cmd)
		{
			DataTable table = new DataTable();
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();

			//Определяем максимальный размер данных в каждом поле таблицы:
			int[] string_sizes = new int[reader.FieldCount];    //Этот массив хранит максимальные размеры строк для каждого поля.
			int interval = 15;
			//Вычисляем максимальные размеры строк:
			for (int i = 0; i < reader.FieldCount; i++)
				if (reader.GetName(i).ToString().Length > string_sizes[i])
					string_sizes[i] = reader.GetName(i).ToString().Length + interval;
			while (reader.Read())
			{
				for (int i = 0; i < reader.FieldCount; i++)
				{
					if (reader[i].ToString().Length > string_sizes[i])
						string_sizes[i] = reader[i].ToString().Length + interval;
				}
			}
			reader.Close();
			//Заново выполняем запрос, и выводим результаты запроса:
			reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				table.Columns.Add(reader.GetName(i));

				Console.Write($"{reader.GetName(i).PadRight(string_sizes[i])}");
				//if (reader.GetName(i).ToString().Length > string_sizes[i]) string_sizes[i] = reader.GetName(i).ToString().Length + 1;
			}
			Console.WriteLine();
			for (int i = 0; i < string_sizes.Sum(); i++) Console.Write("-"); Console.WriteLine();
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.Write(reader[i].ToString().PadRight(string_sizes[i]));
					row[i] = reader[i];
				}
				Console.WriteLine();
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			return table;
		}
		public DataTable Select(string fields, string tables, string condition = "")
		{
			string cmd = $"SELECT {fields} FROM {tables} ";
			if (condition != "") cmd += $" WHERE {condition}";
			return Select(cmd);
		}
		public object Scalar(string cmd)
		{
			object value = null;
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			value = command.ExecuteScalar();
			connection.Close();
			return value;
		}
		public string GetPrimaryKeyColumnName(string table)
		{
			//@"RAW - строка, она игнорирует Escape-последовательности, символы переноса и доугие спец-символы"
			string cmd = $@"
SELECT	COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
WHERE CONSTRAINT_NAME =
(
SELECT  CONSTRAINT_NAME
FROM    INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE   TABLE_NAME = N'{table}'
AND CONSTRAINT_TYPE = N'PRIMARY KEY'
);";
			return Scalar(cmd).ToString();
		}
		public int GetLastPrimayKey(string table)
		{
			return (int)Scalar($"SELECT MAX({GetPrimaryKeyColumnName(table)}) FROM {table}");
		}
		public int GetNextPrimaryKey(string table)
		{
			return GetLastPrimayKey(table) + 1;
		}
		public void Insert(string cmd)
		{
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void Insert(string table, string fields, string values)
		{
			string[] split_fields = fields.Split(',');
			string[] split_values = values.Split(',');
			if (split_fields.Length != split_values.Length) return;
			string condition = "";
			for (int i = 1; i < split_values.Length; i++)
			{
				condition += $"{split_fields[i]}={split_values[i]}";
				if (i != split_values.Length - 1)
					condition += " AND ";
			}
			if (Scalar($"SELECT {GetPrimaryKeyColumnName(table)} FROM {table} WHERE {condition} ") == null)
				Insert($"INSERT {table}({fields}) VALUES({values})");
		}
		public void Update(string cmd)
		{
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void Update(string table, string fields, string values, string condition)
		{
			string[] s_fields = fields.Split(',');
			string[] s_values = values.Split(',');
			if (s_fields.Length != s_values.Length) return;
			string parsed = " ";
			for (int i = 0; i < s_fields.Length; i++)
			{
				parsed += $"{s_fields[i]}={ParseValue(s_values[i])}";
				if (i != s_values.Length - 1) parsed += ",";
			}
			string cmd = $"UPDATE {table} SET {parsed} WHERE {condition}";
			if (Scalar($"SELECT {GetPrimaryKeyColumnName(table)} FROM {table} WHERE {parsed.Replace(",", " AND ")} ") == null)
				Update(cmd);
		}
		string ParseValue(string value)
		{
			if (value.Length > 1)
			{
				value = value.Trim();	//Метод Trim() удаляет пробелы в начале и в конце строки
				if (value[0] != 'N' && value[1] != '\'') value = $"N'{value}'";
				/*
				-------------------------
				\ (Backslash) - символ отмены специального значения другого символа.
				-------------------------
				*/
			}
			return value;
		}
	}
}
