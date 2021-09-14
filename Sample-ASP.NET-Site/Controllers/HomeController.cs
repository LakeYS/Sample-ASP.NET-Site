using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample_ASP.NET_Site.Models;
using Sample_ASP.NET_Site.DAL;

namespace Sample_ASP.NET_Site.Controllers
{
    public class HomeController : Controller
    {
        private IManagerRepository managerRepository;

        public HomeController()
        {
            this.managerRepository = new ManagerRepository(new ManagerContext());
        }

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
                managerRepository.UpdateClient(client);
                managerRepository.Save();

                return Json(ModelState.ToDataSourceResult());
            }
        }

        public ActionResult InsertClient([DataSourceRequest] DataSourceRequest request, Client target)
        {
            if (ModelState.IsValid)
            {
                managerRepository.InsertClient(target);
                managerRepository.Save();
            }

            return Json(new[] { target }.ToDataSourceResult(request));
        }

        public ActionResult DeleteClient([DataSourceRequest] DataSourceRequest request, Client client)
        {
            var target = managerRepository.GetClientByID(client.ID);

            managerRepository.DeleteClient(client.ID);
            managerRepository.Save();

            return Json(new[] { target }.ToDataSourceResult(request));
        }
    }
}
