using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.BusinessLogic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]
        public ViewModel_Index Index()
        {
            GrowBl bl = new GrowBl();
            var firstPageData = bl.GetFirstPageData();

            return firstPageData;
        }
        
        [HttpGet]
        public List<PersonRecord> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            else
            {
                var result = new PersonDetailJsonModel();

                int person = Convert.ToInt32(id);
                GrowBl bl = new GrowBl();
                var alldata = bl.GetPersonAllData(person);
                
                return alldata;
            }
        }

        [HttpGet]
        public string test()
        {
            return "api works";
        }

        [HttpOptions]
        [HttpPost]
        public string Create([FromBody] NewData newdata )
        {
            if (newdata == null || newdata.id == 0)
            {
                return "";
            }
           
            
            PersonRecord toinsert = new PersonRecord(0, newdata.id, "", newdata.weight, 0, DateTime.Now, "");

            GrowBl insertHandler = new GrowBl();
            insertHandler.InsertNewData(toinsert); 


            return newdata.weight.ToString();
        }
    }
}


public class NewData {

    public int id;

    public decimal weight;
}