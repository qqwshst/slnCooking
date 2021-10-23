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

        public ActionResult 報名紀錄(int? sort, int? statu, int page = 1)
        {
            // 排序 0新 1舊
            // 狀態 3 全部
            if(Session["key"] != null)
            {
                // session取得會員資料

                CCaptureRecords crs = new CCaptureRecords();
                C主辦Or報名ViewModel vmodel = new C主辦Or報名ViewModel();
                List<CCaptureMeetInfo> data = crs.撈取報名記錄(1, sort, statu);

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

                vmodel.Info = crs.GetPageList(data, page);
                
                return View(vmodel);
            }

            return RedirectToAction("", "");
        }

        public ActionResult 主辦紀錄(int? sort, int page = 1)
        {
            if (Session["key"] != null)
            {
                CCaptureRecords crs = new CCaptureRecords();
                C主辦Or報名ViewModel vmodel = new C主辦Or報名ViewModel();
                List<CCaptureMeetInfo> data = crs.撈取主辦記錄(1, sort);

                if(sort != null)
                {
                    vmodel.CurrentSort = sort.ToString();
                }

                vmodel.Info = crs.GetPageList(data, page);

                return View(vmodel);
            }

            return RedirectToAction("", "");
        }
    }
}