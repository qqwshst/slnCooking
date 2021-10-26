using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;
using prjCooking.ViewModel;

namespace prjCooking.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult 註冊()
        {            
            t會員 註冊 = new t會員();
            註冊.f會員姓名 = Request.Form["txtName"];
            註冊.f會員信箱 = Request.Form["txtEmail"];
            註冊.f會員密碼 = Request.Form["txtPwd"];
            if (Request.Form["txtGender"] != null)
            {
                註冊.f性別 = int.Parse(Request.Form["txtGender"]);
            };

            Session[CSessionKey.註冊會員_t會員] = 註冊;
            return RedirectToAction("Create");
        }

    }
}