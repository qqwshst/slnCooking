using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;
using System.Web.Security;
using prjCooking.ViewModel;

namespace prjCooking.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            C主頁面撈取 撈取 = new C主頁面撈取();
            C主頁面展示ViewModel vmodel = new C主頁面展示ViewModel();
            vmodel.全部聚會 = 撈取.所有聚會();


            return View(vmodel);
        }
    }
}