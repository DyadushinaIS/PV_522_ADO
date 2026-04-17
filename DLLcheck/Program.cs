using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using DBtools;

namespace DLLcheck
{
	class Program
	{
		static void Main(string[] args)
		{
			Connector connector = new Connector
				(
				ConfigurationManager.ConnectionStrings["Movies_PV_522"].ConnectionString
				);

			connector.Update("UPDATE Directors SET last_name=N'Tagtgren' WHERE director_id=8");

			//connector.Update("Directors", "first_name,last_name", "Michael,Jackson", "director_id=9");
			connector.Update("Directors", "first_name,last_name", "James , Cameron", "director_id=9");

			connector.Select("*", "Directors");
			connector.Select
				(
				"title,release_date,first_name,last_name",
				"Movies,Directors",
				"director=director_id"
				);

			Connector connectorAcademy = new Connector
				(
				ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString
				);
			connectorAcademy.Select("*", "Disciplines");
		}
	}
}
