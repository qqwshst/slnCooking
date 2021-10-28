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

        public ActionResult CreateParty()
        {
            if(Session[CSessionKey.登入會員_t會員] != null)
                return View();

            return RedirectToAction("登入", "Member");
        }

        [HttpPost]
        public ActionResult CreateParty(C主辦聚會ViewModel 新增聚會資訊)
        {
            dbCookingEntities db = new dbCookingEntities();

            // 建立 聚會活動
            新增聚會資訊.主辦聚會資訊.f主辦人 = ((t會員)Session[CSessionKey.登入會員_t會員]).f會員Id;
            新增聚會資訊.主辦聚會資訊.f聚會狀態 = (int)聚會狀態.可報名;
            新增聚會資訊.主辦聚會資訊.f聚會垃圾桶 = Convert.ToBoolean(聚會垃圾桶.顯示);
            新增聚會資訊.主辦聚會資訊.f聚會開始時間 = CDateTime合併.合併(新增聚會資訊.聚會日期, 新增聚會資訊.聚會開始時間);
            新增聚會資訊.主辦聚會資訊.f聚會結束時間 = CDateTime合併.合併(新增聚會資訊.聚會日期, 新增聚會資訊.聚會結束時間);
            新增聚會資訊.主辦聚會資訊.f聚會建立日期 = DateTime.Now;

            if (新增聚會資訊.上傳的圖片 != null)
            {
                string new照片名字 = C上傳圖片檔案重新命名.Get新名字(新增聚會資訊.上傳的圖片);
                新增聚會資訊.主辦聚會資訊.f聚會照片 = new照片名字;
                新增聚會資訊.上傳的圖片.SaveAs(Server.MapPath("~/image/" +new照片名字));
            }

            db.Cooking新增某表格資料<t聚會>(新增聚會資訊.主辦聚會資訊);

            // 建立 建議食材
            // 尋找聚會id
            List<t聚會> 會員主辦聚會List = db.Cooking查詢某會員聚會ListBy會員Id(新增聚會資訊.主辦聚會資訊.f主辦人);
            if (會員主辦聚會List != null)
            {
                會員主辦聚會List.Reverse();
                int 本次聚會Id = 會員主辦聚會List[0].f聚會Id;

                for (int i = 0; i < 新增聚會資訊.食材名稱List.Count; i++)
                {
                    if (新增聚會資訊.食材名稱List[i] != ""
                        && 新增聚會資訊.食材單位List[i] != ""
                        && 新增聚會資訊.食材數量List[i].HasValue)
                    {
                        db.Cooking新增某表格資料<t建議食材>(new t建議食材()
                        {
                            f食材名稱 = 新增聚會資訊.食材名稱List[i],
                            f數量 = 新增聚會資訊.食材數量List[i].Value,
                            f單位 = 新增聚會資訊.食材單位List[i],
                            f聚會Id = 本次聚會Id
                        });
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }

            return RedirectToAction("showParty");
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