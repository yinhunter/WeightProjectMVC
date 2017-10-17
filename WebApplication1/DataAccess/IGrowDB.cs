using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public interface IGrowDB
    {
        List<PersonRecord> GetAllData();

        List<PersonRecord> GetOnePersonData(int personId);

        void InsertNewData(PersonRecord newRecord);
    }
}
