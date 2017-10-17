using System.Collections.Generic;
using WebApplication1.Models;
using System;

namespace WebApplication1.DataAccess
{
    public class GrowDB : IGrowDB
    {
        public List<PersonRecord> GetAllData()
        {	
			// using cache 
			CVSHandler x = new CVSHandler();

            List<PersonRecord> results = x.LoadFile();

            results.Sort(
                delegate (PersonRecord p1, PersonRecord p2)
                {
                    return p2.RecordDate.CompareTo(p1.RecordDate);
                }
                );

            return results; 
		}

        public List<PersonRecord> GetOnePersonData(int personId)
        {
            return GetAllData().FindAll(item => item.PersonId == personId);
        }

        public void InsertNewData(PersonRecord newRecord)
        {
			// todo: DB logic to add new record
			// then udpate the cached

			CVSHandler x = new CVSHandler();
			x.AppendRecord(newRecord);

            GetAllData();
        }



        private List<PersonRecord> GetTestData()
        {
            List<PersonRecord> tmp = new List<PersonRecord>();

            tmp.Add(new PersonRecord(1, 1, "Li",(decimal)177.2, 0, new DateTime(2014, 03, 28), ""));
            tmp.Add(new PersonRecord(2, 1, "Li", (decimal)175.6, 0, new DateTime(2014, 05, 15), ""));
            tmp.Add(new PersonRecord(3, 1, "Li", (decimal)172, 0, new DateTime(2014, 08, 13), ""));
            tmp.Add(new PersonRecord(4, 1, "Li", (decimal)164, 0, new DateTime(2015, 01, 09), ""));
            tmp.Add(new PersonRecord(5, 1, "Li", (decimal)167, 0, new DateTime(2015, 06, 29), ""));
            tmp.Add(new PersonRecord(6, 1, "Li", (decimal)178, 0, new DateTime(2017, 04, 09), ""));


            tmp.Add(new PersonRecord(7, 2, "Lili",(decimal)136.2, 0, new DateTime(2014, 03, 28), ""));
            tmp.Add(new PersonRecord(8, 2, "Lili",(decimal)128.2, 0, new DateTime(2014, 07, 02), ""));
            tmp.Add(new PersonRecord(9, 2, "Lili", (decimal)120.2, 0, new DateTime(2014, 08, 28), ""));
            tmp.Add(new PersonRecord(10, 2, "Lili", (decimal)116.2, 0, new DateTime(2015, 05, 28), ""));
            tmp.Add(new PersonRecord(11, 2, "Lili", (decimal)115.2, 0, new DateTime(2015, 06, 21), ""));
            tmp.Add(new PersonRecord(12, 2, "Lili", (decimal)118, 0, new DateTime(2017, 06, 15), ""));


            tmp.Add(new PersonRecord(13, 3, "Alisha", (decimal)41.4, 0, new DateTime(2014, 03, 28), ""));
            tmp.Add(new PersonRecord(14, 3, "Alisha", (decimal)43, 0, new DateTime(2014, 09, 28), ""));
            tmp.Add(new PersonRecord(15, 3, "Alisha", (decimal)45, 0, new DateTime(2015, 03, 28), ""));
            tmp.Add(new PersonRecord(16, 3, "Alisha", (decimal)45, 0, new DateTime(2015, 05, 14), ""));
            tmp.Add(new PersonRecord(17, 3, "Alisha", (decimal)48.6, 0, new DateTime(2015, 11, 28), ""));
            tmp.Add(new PersonRecord(18, 3, "Alisha", (decimal)54, 0, new DateTime(2017, 07, 01), ""));


            tmp.Add(new PersonRecord(19, 4, "Arthur", (decimal)8.8, 0, new DateTime(2014, 03, 28), ""));
            tmp.Add(new PersonRecord(20, 4, "Arthur", (decimal)14.6, 0, new DateTime(2014, 05, 28), ""));
            tmp.Add(new PersonRecord(21, 4, "Arthur", (decimal)17.2, 0, new DateTime(2014, 08, 10), ""));
            tmp.Add(new PersonRecord(22, 4, "Arthur", (decimal)21, 0, new DateTime(2014, 11, 15), ""));
            tmp.Add(new PersonRecord(23, 4, "Arthur", (decimal)26, 0, new DateTime(2015, 09, 01), ""));
            tmp.Add(new PersonRecord(24, 4, "Arthur", (decimal)30, 0, new DateTime(2016, 02, 03), ""));
            tmp.Add(new PersonRecord(25, 4, "Arthur", (decimal)36, 0, new DateTime(2017, 06, 15), ""));


            return tmp;
        }
    }
}