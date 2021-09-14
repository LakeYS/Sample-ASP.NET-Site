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
		public ActionResult GetClients([DataSourceRequest] DataSourceRequest request)
		{
            using (var dbContext = new ManagerContext())
            {
                var returnVal = Json(dbContext.Clients.ToDataSourceResult(request,
                c => new Client
                {
                    ID = c.ID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Timestamp = c.Timestamp
                }));

                return returnVal;
            }
        }

        public ActionResult UpdateClient([DataSourceRequest] DataSourceRequest request, Client client)
        {
            using (var dbContext = new ManagerContext())
            {
                var customerToUpdate = dbContext.Clients.First(cust => cust.ID == client.ID);

                TryUpdateModel(customerToUpdate);

                dbContext.SaveChanges();

                return Json(ModelState.ToDataSourceResult());
            }
        }

        public ActionResult InsertClient([DataSourceRequest] DataSourceRequest request, Client target)
        {
            using (var dbContext = new ManagerContext())
            {
                if (ModelState.IsValid)
                {
                    dbContext.Clients.Add(target);
                    dbContext.SaveChanges();
                }

                return Json(new[] { target }.ToDataSourceResult(request));
            }
        }

        public ActionResult DeleteClient([DataSourceRequest] DataSourceRequest request, Client client)
        {
            using (var dbContext = new ManagerContext())
            {
                var target = dbContext.Clients.First(cust => cust.ID == client.ID);

                if (target != null)
                {
                    dbContext.Clients.Remove(target);
                    dbContext.SaveChanges();
                }

                return Json(new[] { target }.ToDataSourceResult(request));
            }
        }
    }
}
