using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Configuration;
using System.Web;
using System.Runtime.Caching;



namespace WebApplication1.DataAccess
{
    public class DBHandler
    {
        
        private string Getconnectionstring()
        {
            string connectionstring = "";
            string host = HttpContext.Current.Request.Url.Host;
            if (host.Contains("localhost"))
                connectionstring = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString() ;
            else
                connectionstring = ConfigurationManager.ConnectionStrings["remoteServer"].ToString();

            return connectionstring;
        }

        public List<PersonRecord> LoadFile()
        {
            ObjectCache cache = MemoryCache.Default;
            var cacheContent = cache["loaded"];
            if (cacheContent == null)
            {
                return LoadFilefromDB();
            }
            else
            {
                return (List<PersonRecord>)cacheContent;
            }            
        }

        private List<PersonRecord> LoadFilefromDB()
        {            
            List<PersonRecord> resultSet = new List<PersonRecord>();

            using (var conn = new SqlConnection(Getconnectionstring()))
            using (var command = new SqlCommand("dbo.sp_get_all_in_one", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            })
            {
                conn.Open();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        PersonRecord tmpPerson = new PersonRecord(
                                    Convert.ToInt32(rdr["RecordSN"]),
                                    Convert.ToInt32(rdr["PersonID"]),
                                    (string)rdr["Name"],
                                    Convert.ToDecimal(rdr["Weight"]),
                                    Convert.ToDecimal(rdr["Height"]),
                                    Convert.ToDateTime(rdr["RecordDate"]),
                                    (string)rdr["Comments"]);

                        resultSet.Add(tmpPerson);
                    }
                }
            }

            CacheItemPolicy newpolicy = new CacheItemPolicy();
            newpolicy.SlidingExpiration = TimeSpan.FromMinutes(30.00);
            ObjectCache cache = MemoryCache.Default;
            cache.Set("loaded", resultSet, newpolicy);

            return resultSet;
        }

        public void AppendRecord(PersonRecord toAdd)
        {
            string query = "insert into records (PersonID, Weight,RecordDate, Height, Comments) VALUES (" + toAdd.PersonId + "," + toAdd.Weight + ",'" + toAdd.RecordDate.ToShortDateString() + "',0,'');";
            using (SqlConnection connection = new SqlConnection(Getconnectionstring()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int resultaat = command.ExecuteNonQuery();
                    if (resultaat == 1)
                    {

                    }
                    else
                    {

                    }
                }
            }

            LoadFilefromDB();

        }
    }
}