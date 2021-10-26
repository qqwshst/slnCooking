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
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult 登入(string 信箱, string 密碼)
        {
            dbCookingEntities db = new dbCookingEntities();
            string show = "";
            if (Request.Form["txtEmail"] != null && Request.Form["txtPwd"] != null)
            {
                var m = from t會員 in db.t會員
                        where t會員.f會員信箱 == Request.Form["txtEmail"] & t會員.f會員密碼 == Request.Form["txtPwd"]
                        select t會員;


                if (m != null)
                {
                    t會員 登入 = new t會員();
                    登入.f會員信箱 = Request.Form["txtEmail"];
                    登入.f會員密碼 = Request.Form["txtPwd"];

                    Session[CSessionKey.登入會員_t會員] = 登入;
                    return View("Create");
                }
                else
                {
                    show = "帳號密碼錯誤";
                }
            }
            else
            {
                show = "請輸入帳號密碼";
            }

            return View();

        }


        [HttpPost]
        public ActionResult 註冊()
        {            
            t會員 註冊 = new t會員();            
            註冊.f會員信箱 = Request.Form["txtEmail"];
            註冊.f會員密碼 = Request.Form["txtPwd"];
            註冊.f會員姓名 = Request.Form["txtName"];
            if (Request.Form["txtGender"] != null)
            {
                註冊.f性別 = int.Parse(Request.Form["txtGender"]);
            };

            Session[CSessionKey.註冊會員_t會員] = 註冊;
            return RedirectToAction("Create");
        }

    }
}