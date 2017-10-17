using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BusinessLogic
{
    interface IGrowBl
    {
		//1. return the first page content
		// call GetLatestFiveData 4 times to get the data for first page
		ViewModel_Index GetFirstPageData();

        List<PersonRecord> GetPersonAllData(int personId);

        //3. create new
        void InsertNewData(PersonRecord newRecord);
    }
}
