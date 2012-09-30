using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarDaLuz.Db;

namespace BarDaLuz.Web.Controllers
{
    public class HomeController : Controller
    {
        private BarDaLuzContext db = new BarDaLuzContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome";//db.Database.Connection.ConnectionString;

            return View();
        }
    }
}
