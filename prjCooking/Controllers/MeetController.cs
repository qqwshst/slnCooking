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

        
        public ActionResult CreateParty()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateParty(t聚會 p)
        {
            dbCookingEntities db = new dbCookingEntities();
            db.t聚會.Add(p);
            db.SaveChanges();
            return RedirectToAction("showParty");
        }
        public ActionResult PartyForm()
        {
            return View();
        }
     

        public ActionResult 報名紀錄(int? sort, int? statu, int page = 1)
        {
            // 排序 0新 1舊
            // 狀態 3 全部
            if(Session["key"] != null)
            {
                // session取得會員資料

                C主辦Or報名ViewModel vmodel = new C主辦Or報名ViewModel();
                List<CCaptureMeetInfo> data = (new CCaptureRecords()).撈取報名記錄(1, sort, statu);

                vmodel.Info = data;

                if (sort != null && statu != null) 
                {
                    vmodel.CurrentSort = sort.ToString();
                    vmodel.CurrentStatu = statu.ToString();
                }
                else
                {
                    vmodel.CurrentSort = "0";
                    vmodel.CurrentStatu = "0";
                }

                // 分頁條
                if(data.Count > 0) 
                {
                    int pageSize = 0;
                    if (data.Count % 10 > 0)
                    {
                        pageSize = 1;
                    }

                    pageSize += (data.Count / 10);
                    int currentPage = page < 1 ? 1 : page;
                    vmodel.Pages = vmodel.Info.ToPagedList(currentPage, pageSize);
                }
                
                return View(vmodel);
            }

            return RedirectToAction("", "");
        }

        public ActionResult 主辦紀錄(int? sort, int page = 1)
        {
            if (Session["key"] != null)
            {
                C主辦Or報名ViewModel vmodel = new C主辦Or報名ViewModel();
                List<CCaptureMeetInfo> data = (new CCaptureRecords()).撈取主辦記錄(1, sort);

                vmodel.Info = data;

                if(sort != null)
                {
                    vmodel.CurrentSort = sort.ToString();
                }

                // 分頁條
                if (data.Count > 0)
                {
                    int pageSize = 0;
                    if (data.Count % 10 > 0)
                    {
                        pageSize = 1;
                    }

                    pageSize += (data.Count / 10);
                    int currentPage = page < 1 ? 1 : page;
                    vmodel.Pages = vmodel.Info.ToPagedList(currentPage, pageSize);
                }

                return View(vmodel);
            }

            return RedirectToAction("", "");
        }
    }
}