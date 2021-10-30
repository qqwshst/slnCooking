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
        public ActionResult Edit_info(int id)
        {
            dbCookingEntities db = new dbCookingEntities();
            t會員 prod = db.t會員.FirstOrDefault(p => p.f會員Id == id);
            if (prod == null)
                return RedirectToAction("Show個人頁面");

            return View(new CAllMember() { member = prod });


        }
        [HttpPost]
        public ActionResult Edit_info(CAllMember editProduct)
        {
            dbCookingEntities db = new dbCookingEntities();
            t會員 prod = db.t會員.FirstOrDefault(p => p.f會員Id == editProduct.f會員Id);
            if (prod != null)
            {
                if (editProduct.image != null)
                {
                    //把照片重新命名
                    //讓名稱為唯一值
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    prod.f會員照片 = photoName;
                    editProduct.image.SaveAs(Server.MapPath("../../Image/" + photoName));
                }

                prod.f自我介紹 = editProduct.f自我介紹;
                prod.f會員電話 = editProduct.f會員電話;

                db.SaveChanges();
            }

            return RedirectToAction("Show個人頁面");
        }

        public ActionResult Show個人頁面(int?id)
        {
            if (Session[CSessionKey.登入會員_t會員] == null)
            {
                return RedirectToAction("登入", "Member");
            }
            
           t會員 member_select = (new dbCookingEntities()).Cooking查詢某會員的資料By會員Id(id);

            



            return View(new CAllMember() { member = member_select });

        }

        
        public ActionResult 登入()
        {
            Session.Clear();
            Session.Abandon();
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

        public ActionResult 忘記密碼()
        {
            return View();
        }
        [HttpPost]
        public ActionResult 忘記密碼(string txtEmail, string txtPwd, string txtRePwd, string check)
        {
            dbCookingEntities db = new dbCookingEntities();
            if (txtEmail != "")
            {
                t會員 會員 = db.t會員.Where(m => m.f會員信箱 == txtEmail).FirstOrDefault();

                if (會員 != null)
                {
                    Maill();
                    ViewBag.dis = "disabled";
                    ViewBag.mail = (string)Session[CSessionKey.註冊會員_fEmail];
                }
                else
                {
                    ViewBag.通知訊息 = "此信箱尚未註冊";
                }

                if ((string)Session[CSessionKey.驗證碼_int] != null)
                {
                    var ch = (string)Session[CSessionKey.驗證碼_int];
                    if (ch == check)
                    {
                        if (txtPwd == txtRePwd)
                        {
                            var mail = (string)Session[CSessionKey.註冊會員_fEmail];
                            t會員 newPwd = db.t會員.Where(m => m.f會員信箱 == mail).FirstOrDefault();
                            newPwd.f會員密碼 = txtPwd;
                            db.Cooking修改會員資料(newPwd);

                            return RedirectToAction("登入");
                        }
                        else
                        {
                            ViewBag.通知訊息 = "密碼輸入錯誤";
                        }
                    }
                    else
                    {
                        //驗證碼錯誤
                    }
                }
            }
            else
            {
                ViewBag.通知訊息 = "請輸入帳號";
            }
            return View();
        }

        //請從信箱驗證頁面跳到註冊頁面
        public ActionResult 註冊()
        {
            ViewBag.dis = "disabled";
            ViewBag.驗證mail = (string)Session[CSessionKey.註冊會員_fEmail];
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
            註冊.f會員照片 = "person.svg";

            db.Cooking新增某表格資料<t會員>(註冊);
            
            return RedirectToAction("Index", "Home");
            
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
            i = rnd.Next(1000, 9999);
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