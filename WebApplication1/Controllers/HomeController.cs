using System;
using System.Web.Mvc;
using WebApplication1.BusinessLogic;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GrowBl bl = new GrowBl();
            var firstPageData = bl.GetFirstPageData();
			
            return View(firstPageData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Detail(string id)
        {
			if (string.IsNullOrEmpty(id))
			{
				return View();
			}
			else
			{
				int person = Convert.ToInt32(id);
				GrowBl bl = new GrowBl();
				var alldata = bl.GetPersonAllData(person);
				ViewBag.Message = alldata[0].Name + "'s  Weight Tracking";
				return View(alldata);
			}
		}

		public RedirectToRouteResult Create(string id,string weight)
		{
			if (string.IsNullOrEmpty(id))
			{
				return RedirectToAction("Index");
			}
			
			Models.PersonRecord toinsert = new Models.PersonRecord(0, Convert.ToInt32(id), "", Convert.ToDecimal(weight), 0, DateTime.Now, "");
		   
			GrowBl insertHandler = new GrowBl();
			insertHandler.InsertNewData(toinsert);

			return RedirectToAction("Index");
		}
    }
}