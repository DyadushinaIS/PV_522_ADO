using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;

//ADO.NET
//ADO - ActiveX Data Objects
//.NET
//System.Data
//System.Data.SqlClient

namespace PV_522_ADO
{
	class Program
	{
		static void Main(string[] args)
		{
			//string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_PV_522;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			string connection_string = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
			Connector connector = new Connector(connection_string);

			Console.WriteLine(connector.GetPrimaryKeyColumnName("Movies"));
			Console.WriteLine(connector.GetNextPrimaryKey("Movies"));
			//connector.Insert($"INSERT Directors(director_id,first_name,last_name)VALUES({connector.GetNextPrimaryKey("Directors")},N'Peter',N'Jackson')");

			connector.Insert
				(
				"Directors",
				"director_id,first_name,last_name",
				$"{connector.GetNextPrimaryKey("Directors")},N'Sheldon',N'Letich'"
				);

			connector.Select("SELECT * FROM Directors");
			connector.Select("movie_id,title,first_name,last_name", "Movies,Directors", "director=director_id");

			//Console.WriteLine(connection_string);
			//connection = new SqlConnection(connection_string);

			//string cmd = "SELECT last_name,first_name FROM Directors";
			//Select(cmd);

			//Console.WriteLine($"Количество записей: {Scalar("SELECT COUNT(*) FROM Directors")}");
			//Select("title, release_date, last_name, first_name", "Movies,Directors", "director=director_id");
			/*Select("SELECT title,release_date,first_name,last_name FROM Movies,Directors WHERE director=director_id");*/

		}
		

	}
}
