using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO
{
	internal class Program
	{
		static SqlConnection connection;
		static void Main(string[] args)
		{
			string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_PV_522;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			Console.WriteLine(connection_string);
			connection= new SqlConnection(connection_string);

			string cmd = "SELECT last_name , first_name FROM Directors";
			Select(cmd);
			Console.WriteLine($"Количество записей: {Scalar("SELECT COUNT(*) FROM Directors")}");
			Select("SELECT * FROM Movies");
		}
		static void Select (string cmd)
		{
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();

			//определяем максимальный размер данных в каждом поле таблицы
			int[] string_sizes = new int[reader.FieldCount];
			while(reader.Read())
			{
				for(int i=0;i<reader.FieldCount;i++)
				{
					if (reader[i].ToString().Length > string_sizes[i]) string_sizes[i]=reader[i].ToString().Length+1;
				}
			}
			reader.Close();

			reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
				Console.Write($"{reader.GetName(i).PadRight(string_sizes[i])}\t");
			Console.WriteLine();
			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
				for (int i = 0; i < reader.FieldCount; i++)
					Console.Write(reader[i].ToString().PadRight(string_sizes[i]) + "\t");
				Console.WriteLine();
			}
			reader.Close();
			connection.Close();
		}
		static object Scalar (string cmd)
		{
			object value = null;
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			value=command.ExecuteScalar();			
			connection.Close();
			return value;
		}
	}
}
