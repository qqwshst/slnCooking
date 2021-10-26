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

        public ActionResult 註冊()
        {
            ViewBag.dis = "disabled";
            ViewBag.驗證mail = (string)Session[CSessionKey.註冊會員_fEmail];
            return View();
        }
        public ActionResult 登入()
        {
            return View();
        }
        [HttpPost]
        public ActionResult 登入(string txtEmail, string txtPwd)
        {
            dbCookingEntities db = new dbCookingEntities();
            
            t會員 會員 = null;            
            if (txtEmail != "" && txtPwd != "")
            {
                會員 = db.Cooking查詢某會員的資料By信箱And密碼(txtEmail, txtPwd);

                if (會員 != null)
                {
                    Session[CSessionKey.登入會員_t會員] = 會員;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                     // "帳號密碼錯誤";
                }
            }
            else
            {
                // "請輸入帳號密碼";
            }
            return View();
        }


        [HttpPost]
        public ActionResult 註冊(string txtPwd, string txtName, int txtGender)
        {
            dbCookingEntities db = new dbCookingEntities();
            t會員 註冊 = new t會員();
            註冊.f會員信箱 = (string)Session[CSessionKey.註冊會員_fEmail];
            註冊.f會員密碼 = txtPwd;
            註冊.f會員姓名 = txtName;
            註冊.f性別 = txtGender;
            註冊.f權限 = 0;
            註冊.f會員建立日期 = DateTime.Now;

            db.Cooking新增某表格資料<t會員>(註冊);
            
            return RedirectToAction("Index", "Home");
            //if (Session[CSessionKey.註冊會員_fEmail] != null)
            //{
            //}
            //return View();
        }

        public ActionResult 信箱驗證()
        {
            dbCookingEntities db = new dbCookingEntities();
            if (Request.Form["txtEmail"] != null)
            {
                List<t會員> m = db.Cooking查詢所有會員List();
                foreach (t會員 t in m)
                {
                    if (t.f會員信箱 == Request.Form["txtEmail"])
                    {
                        ViewBag.帳號已存在 = "帳號已存在";
                        return View();
                    }                    
                }
                ViewBag.dis = "disabled";
                ViewBag.mail = Request.Form["txtEmail"];
                Maill();

            }

            if (Session[CSessionKey.驗證碼_int] != null)
            {
                var ch = Request.Form["check"];
                if (((string)Session[CSessionKey.驗證碼_int]) == ch)
                {
                    return RedirectToAction("註冊");
                }
            }

            return View();
        }

        public string random()
        {
            int i;
            Random rnd = new Random();
            i = rnd.Next(1000, 10000);
            return i.ToString();
        }

        private void Maill()
        {
            string rnd = random();
            MailSend maill = new MailSend();

            maill.Path = @"C:\maillAccount.txt";
            maill.FromFileAccountInfo();
            maill.MailSendFromName = "煮吧";
            maill.MailSendToName = "To註冊會員";
            maill.MailSendToAddress = Request.Form["txtEmail"];

            maill.MailTitle = "煮吧註冊驗證碼";
            maill.MailContent = "您的驗證碼:" + rnd;

            // 寄件
            maill.SendMaill();
            //沒取值
            Session[CSessionKey.註冊會員_fEmail] = Request.Form["txtEmail"];
            Session[CSessionKey.驗證碼_int] = rnd;


        }
    }
}