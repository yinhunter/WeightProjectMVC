
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.DataAccess;

namespace WebApplication1.BusinessLogic
{
    public class GrowBl: IGrowBl
    {
        //1. return the first page content
        // call GetLatestFiveData 4 times to get the data for first page
        public ViewModel_Index GetFirstPageData() {

			ViewModel_Index indexData = new ViewModel_Index();
						
			var p1 = GetLatestFiveData(1);
            var p2 = GetLatestFiveData(2);
            var p3 = GetLatestFiveData(3);
            var p4 = GetLatestFiveData(4);

			indexData.Number1 = p1;
			indexData.Number2 = p2;
			indexData.Number3 = p3;
			indexData.Number4 = p4;
			
			return indexData;
        }

        //2. only load the first 5 data for each person
        private List<PersonRecord> GetLatestFiveData(int personId) {
            return GetPersonAllData(personId).GetRange(0, 5);
        }

        public List<PersonRecord> GetPersonAllData(int personId) {
            GrowDB db = new GrowDB();
            return db.GetOnePersonData(personId);
        }

        //3. create new
        public void InsertNewData(PersonRecord newRecord) {
            GrowDB db = new GrowDB();
            db.InsertNewData(newRecord);
        }
    }
}