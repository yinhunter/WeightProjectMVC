using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using WebApplication1.Models;

// obselete
namespace WebApplication1.DataAccess
{
	public class CVSHandler
	{
		private string filePath = HttpContext.Current.Server.MapPath("~/Content/tracking.csv");
		private int maxrecord = 0;
		public List<PersonRecord> LoadFile()
		{
			List<PersonRecord> resultSet = new List<PersonRecord>();            
            
			List<string> listData = new List<string>();
			using (StreamReader reader = new StreamReader(filePath))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					listData.Add(line);					
				}
			}

			foreach (string line in listData) {
				string[] fields =	line.Split(',');
                PersonRecord tmpPerson = new PersonRecord(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[1]),
                                                MapName(fields[1]), Convert.ToDecimal(fields[2]),
                                                Convert.ToDecimal(fields[3]), Convert.ToDateTime(fields[4]),
                                                fields[5] == "0" ? string.Empty : fields[5]);
												
				resultSet.Add(tmpPerson);
				maxrecord = Convert.ToInt32(fields[0]);
			}
			
			return resultSet;
		}

		private string MapName(string personid)
		{
			string name = "";
			switch (personid)
			{
				case "1":
					name = "Li";
					break;

				case "2":
					name = "Lili";
					break;

				case "3":
					name = "Alisha";
					break;

				case "4":
					name = "Arthur";
					break;
			}
			return name;
		}

		public void AppendRecord(PersonRecord toAdd)
		{
			//todo: newrecordid 
			LoadFile();
			int newmx = maxrecord + 1;
			string newreocrd = newmx + "," + toAdd.PersonId + "," + toAdd.Weight + ",0," + toAdd.RecordDate.ToShortDateString() + ",0";

			using (StreamWriter w = File.AppendText(filePath))
			{
				w.WriteLine(newreocrd);
			}
		}
	}
}