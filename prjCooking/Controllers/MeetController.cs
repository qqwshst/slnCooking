using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;
using prjCooking.ViewModel;
using PagedList;

namespace prjCooking.Controllers
{
    public class MeetController : Controller
    {
        // GET: Meet
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showParty()
        {

            return View();
        }
        public ActionResult PartyForm()
        {

            return View();
        }
        public ActionResult CreateFood()
        {
            return View();
        }

        public ActionResult CreateParty()
        {
            ViewBag.email = ((t會員)Session[CSessionKey.登入會員_t會員]).f會員信箱;
            return View();
        }


        public ActionResult SaveParty()
        {
            dbCookingEntities db = new dbCookingEntities();
            t聚會 Addparty = new t聚會();
            Addparty.f主辦人 = ((t會員)Session[CSessionKey.登入會員_t會員]).f會員Id;
            Addparty.f聚會名稱 = Request.Form["f聚會名稱"];
            Addparty.f聚會內容 = Request.Form["f聚會內容"];
            Addparty.f聚會關鍵字 = Request.Form["f聚會關鍵字"];
            Addparty.f聚會軟體 = Request.Form["f聚會軟體"];
            Addparty.f聚會軟體URL = Request.Form["f聚會軟體URL"];
            Addparty.f聚會日期 = Convert.ToDateTime(Request.Form["f聚會日期"]);
            Addparty.f聚會開始時間 = Convert.ToDateTime(Request.Form["f聚會日期"] + " " + Request.Form["f聚會開始時間"]);
            Addparty.f聚會結束時間 = Convert.ToDateTime(Request.Form["f聚會日期"] + " " + Request.Form["f聚會結束時間"]);
            Addparty.f名額 = Convert.ToInt32(Request.Form["f名額"]);
            Addparty.f聚會通訊軟體 = Request.Form["f聚會通訊軟體"];
            Addparty.f聚會通訊軟體帳號 = Request.Form["f聚會通訊軟體帳號"];
            Addparty.f聚會垃圾桶 = false;
            Addparty.f聚會建立日期 = DateTime.Now;

            if (Addparty.f聚會開始時間 > DateTime.Now)
                Addparty.f聚會狀態 = Convert.ToInt32(聚會狀態.可報名);
            else if ((Addparty.f聚會開始時間 < DateTime.Now) && (Addparty.f聚會結束時間 > DateTime.Now))
                Addparty.f聚會狀態 = Convert.ToInt32(聚會狀態.進行中);
            else
                Addparty.f聚會狀態 = Convert.ToInt32(聚會狀態.已結束);
            
            db.t聚會.Add(Addparty);
            db.SaveChanges();

            return RedirectToAction("CreateFood", "Meet");
        }

        public ActionResult 報名紀錄(int? sort = 0, int? statu = 3, int page = 1)
        {
            // 排序 0新 1舊
            // 狀態 3 全部
            if(Session[CSessionKey.登入會員_t會員] != null)
            {
                // session取得會員資料
                int 會員Id = ((t會員)Session[CSessionKey.登入會員_t會員]).f會員Id;
                CCaptureRecords crs = new CCaptureRecords();
                C主辦Or報名ViewModel vmodel = new C主辦Or報名ViewModel();
                List<CCaptureMeetInfo> data = crs.撈取報名記錄(會員Id, sort, statu);
                vmodel.Info = crs.GetPageList(data, page);

                if (sort != null && statu != null) 
                {
                    vmodel.CurrentSort = sort.ToString();
                    vmodel.CurrentStatu = statu.ToString();
                }
                
                return View(vmodel);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult 主辦紀錄(int? sort = 0, int page = 1)
        {
            if (Session[CSessionKey.登入會員_t會員] != null)
            {
                int 會員Id = ((t會員)Session[CSessionKey.登入會員_t會員]).f會員Id;
                CCaptureRecords crs = new CCaptureRecords();
                C主辦Or報名ViewModel vmodel = new C主辦Or報名ViewModel();
                List<CCaptureMeetInfo> data = crs.撈取主辦記錄(會員Id, sort);
                vmodel.Info = crs.GetPageList(data, page);

                if (sort != null)
                {
                    vmodel.CurrentSort = sort.ToString();
                }

                return View(vmodel);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult 資格審核(int? meetId)
        {
            // 判斷Session
            if(Session[CSessionKey.登入會員_t會員] != null)
            {
                if(meetId != null)
                {
                    C資格審核ViewModel vmodel = new C資格審核ViewModel();
                    C撈取資格審核名單 撈取 = new C撈取資格審核名單();

                    // 撈取已核准名單
                    bool 核准 = Convert.ToBoolean(參加者審核狀態.通過);
                    if (撈取.Set撈取(1, meetId, 核准))
                        vmodel.核准 = 撈取.Get();

                    // 撈取未審核名單
                    bool? 未審核 = Convert.ToBoolean(參加者審核狀態.未通過);
                    if(撈取.Set撈取(1, meetId, 未審核))
                        vmodel.未審核 = 撈取.Get();

                    return View(vmodel);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult 取消報名(int? 聚會Id)
        {
            // session 抓會員id
            if(Session[CSessionKey.登入會員_t會員] != null)
            {
                int 會員Id = ((t會員)Session[CSessionKey.登入會員_t會員]).f會員Id;
                (new C聚會相關操作()).取消報名(會員Id, 聚會Id.Value);
                return RedirectToAction("報名紀錄");
            }

            return RedirectToAction("index", "Home");
        }

        public ActionResult 取消活動(int? 聚會Id)
        {
            // session 抓會員id
            if(Session[CSessionKey.登入會員_t會員] != null)
            {
                (new C聚會相關操作()).取消活動(聚會Id.Value);
                return RedirectToAction("主辦紀錄");
            }

            return RedirectToAction("index", "Home");
        }

        public ActionResult 核准參加者(int? 聚會Id, int? 參加者Id)
        {
            // 判斷是否有登入
            if(Session[CSessionKey.登入會員_t會員] != null)
            {
                (new C聚會相關操作()).核准參加者(聚會Id.Value, 參加者Id.Value);

                return RedirectToAction("資格審核");
            }

            return RedirectToAction("index", "Home");
        }
    }
}