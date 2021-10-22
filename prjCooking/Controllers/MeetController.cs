using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCooking.Models;

namespace prjCooking.Controllers
{
    public class MeetController : Controller
    {
        // GET: Meet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult 報名紀錄(int? sort, int? statu)
        {
            // 排序 0新 1舊
            // 狀態 3 全部
            if(sort != null && statu != null)
            {
                // session取得會員資料

                List<CCaptureMeetInfo> data = (new CCaptureRecords()).撈取報名記錄(1, sort.Value, statu.Value);

                if (sort.Value == 0)
                    ViewBag.sort = "新-舊";
                else
                    ViewBag.sort = "舊-新";

                if (statu.Value == 3)
                    ViewBag.statu = "全部";
                if (statu.Value == 0)
                    ViewBag.statu = "報名中";
                else
                    ViewBag.statu = data[0].聚會狀態Name;

                return View(data);
            }

            return RedirectToAction("", "");
        }
    }
}