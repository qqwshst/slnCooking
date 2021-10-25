using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;
using System.Web.Security;


namespace prjCooking.Controllers
{
    public class HomeController : Controller
    {
        dbCookingEntities db = new dbCookingEntities();

        // GET: Home
        public ActionResult Index()
        {
            var parties = db.t聚會
                .OrderByDescending(m => m.f聚會建立日期).ToList();


            return View(parties);
        }
    }
}