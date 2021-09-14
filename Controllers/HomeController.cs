using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample_ASP.NET_Site.Models;

namespace Sample_ASP.NET_Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
		public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
		{
			var result = Enumerable.Range(0, 50).Select(i => new Client
			{
				ID = i,
				LastName = "Doe",
				FirstName = "John",
				Timestamp = new DateTime(1631570697845)
			});

			return Json(result.ToDataSourceResult(request));
		}
	}
}
