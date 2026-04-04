using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADO
{
    class Connector
    {
        SqlConnection connection;
        public Connector(string connection_string)
        {
            connection=new SqlConnection(connection_string);
            Console.WriteLine(connection.ConnectionString);
        }
        public void Select(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            //определяем максимальный размер данных в каждом поле таблицы
            int[] string_sizes = new int[reader.FieldCount];  //этот массив хранит максимальные размеры строк для каждого поля
            int interval = 8;

            //Вычисляем максимальные размеры строк: 
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).ToString().Length > string_sizes[i])
                    string_sizes[i] = reader.GetName(i).ToString().Length + interval;
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader[i].ToString().Length > string_sizes[i]) string_sizes[i] = reader[i].ToString().Length + interval;
                }
            }
            reader.Close();

            //заново выполняем запрос и выводим результаты запроса: 
            reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i).PadRight(string_sizes[i])}");
                //if (reader.GetName(i).ToString().Length > string_sizes[i]) string_sizes[i]=reader.GetName(i).ToString().Length+1;
            }
            Console.WriteLine();
            for (int i = 0; i < string_sizes.Sum(); i++) Console.Write("-");
            Console.WriteLine();

            while (reader.Read())
            {
                //Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader[i].ToString().PadRight(string_sizes[i]));
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }

        public void Select(string fields, string tables, string condition = "")
        {
            string cmd = $"SELECT {fields} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            Select(cmd);
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
            string cmd = $@"
SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
WHERE CONSTRAINT_NAME= 
(
SELECT CONSTRAINT_NAME 
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
WHERE TABLE_NAME=N'{table}'
AND CONSTRAINT_TYPE=N'PRIMARY KEY'
);";
            return Scalar(cmd).ToString();
        }

        public int GetLastPrimaryKey(string table)
        {
            return (int)Scalar($"SELECT MAX ({GetPrimaryKeyColumnName(table)}) FROM {table}");
        }

        public int GetNextPrimaryKey (string table)
        {
            return GetLastPrimaryKey(table) + 1;
        }

        public void Insert (string cmd)
        {
            SqlCommand command=new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
