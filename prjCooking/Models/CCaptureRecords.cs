// 撈取報名、舉辦的活動
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjCooking.Models
{
    public class CCaptureRecords
    {
        dbCookingEntities db;

        public CCaptureRecords()
        {
            db = new dbCookingEntities();
        }

        public List<CCaptureMeetInfo> 撈取報名記錄(int memberId)
        {
            List<CCaptureMeetInfo> cmi = db.t參加者.Where(m => m.f會員Id == memberId)
                .OrderBy(m => m.f參加者建立日期)
                .Select(m => new CCaptureMeetInfo { 
                    主辦人 = m.t聚會.t會員.f會員姓名,
                    聚會名稱 = m.t聚會.f聚會名稱,
                    聚會日期 = m.t聚會.f聚會日期,
                    聚會狀態Number = m.t聚會.f聚會狀態.Value,
                    聚會狀態Name = Enum.GetName(typeof(聚會狀態), m.t聚會.f聚會狀態.Value)
                }).ToList();

            return cmi;
        }

        public List<CCaptureMeetInfo> 撈取主辦記錄(int memberId)
        {
            List<CCaptureMeetInfo> cmi = db.t聚會.Where(meet => meet.f主辦人 == memberId)
                .OrderBy(meet => meet.f聚會建立日期)
                .Select(meet => new CCaptureMeetInfo { 
                    主辦人 = meet.t會員.f會員姓名,
                    聚會名稱 = meet.f聚會名稱,
                    聚會日期 = meet.f聚會日期,
                    聚會狀態Number = meet.f聚會狀態.Value,
                    聚會狀態Name = Enum.GetName(typeof(聚會狀態), meet.f聚會狀態.Value),
                    人數上限 = meet.f名額.Value,
                    目前人數 = meet.t參加者.Count()
                }).ToList();

            return cmi;
        }
    }
}