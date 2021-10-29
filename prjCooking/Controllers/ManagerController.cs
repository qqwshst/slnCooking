﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;
using prjCooking.ViewModel;

namespace prjCooking.Controllers
{
    public class ManagerController : Controller
    {

        // GET: Manager
        public ActionResult PartyList()
        {


            IEnumerable<t聚會> datas = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
                datas = from p in (new dbCookingEntities()).t聚會 select p;
            else
                datas = from p in (new dbCookingEntities()).t聚會 where p.f聚會名稱.Contains(keyword) select p;

            List<C管理者聚會ViewModel> Plist = new List<C管理者聚會ViewModel>();

            //聚會資料放進viewmodel
            foreach (t聚會 p in datas)
            {
                Plist.Add(new C管理者聚會ViewModel() { party = p });

            }
            //修正部分viewmodel顯示資訊
            foreach (C管理者聚會ViewModel p in Plist)
            {
                t會員 member = (new dbCookingEntities()).Cooking查詢某會員的資料By會員Id(p.f主辦人);

                //建立日期轉換只顯示年月日
                p.聚會建立日期 = Convert.ToDateTime(p.f聚會建立日期).ToShortDateString();

                p.煮辦人姓名 = member.f會員姓名;

                string party狀態;
                if (p.f聚會狀態 == Convert.ToInt32(聚會狀態.可報名))
                    party狀態 = "可報名";
                else if (p.f聚會狀態 == Convert.ToInt32(聚會狀態.進行中))
                    party狀態 = "進行中";
                else
                    party狀態 = "已結束";
                p.聚會狀態 = party狀態;
                if (p.f聚會垃圾桶 == false)
                    p.聚會垃圾桶 = " ";
                else
                    p.聚會垃圾桶 = "✘";

            }


            return View(Plist);
        }
        public ActionResult Details(int id)
        {
 
            dbCookingEntities db = new dbCookingEntities();
            t會員 member_select = db.t會員.FirstOrDefault(p => p.f會員Id == id);
            if (member_select == null)
                return RedirectToAction("List");

            return View(new C管理者會員ViewModel() { member = member_select });

        }
        public ActionResult Delete(int id)
        {
            dbCookingEntities db = new dbCookingEntities();
            t會員 member_select = db.t會員.FirstOrDefault(p => p.f會員Id == id);
            if (member_select != null)
            {
                db.t會員.Remove(member_select);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            IEnumerable<t會員> datas = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
                datas = from p in (new dbCookingEntities()).t會員 select p;
            else
                datas = from p in (new dbCookingEntities()).t會員 where p.f會員姓名.Contains(keyword) || p.f會員信箱.Contains(keyword) select p;


            List<C管理者會員ViewModel> list = new List<C管理者會員ViewModel>();
            foreach (t會員 p in datas)
                list.Add(new C管理者會員ViewModel() { member = p });
            return View(list);

        }
    }
}