using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjCooking.Models
{
    public class C聚會相關操作
    {
        private dbCookingEntities _db;

        public C聚會相關操作()
        {
            _db = new dbCookingEntities();
        }

        public void 取消報名(int 會員Id, int 聚會Id)
        {
            某一個參加者(聚會Id, 會員Id).f報名 = true;

            _db.SaveChanges();
        }

        public void 取消活動(int 聚會Id)
        {
            t聚會 取消的活動 = _db.t聚會.Where(聚會 => 聚會.f聚會Id == 聚會Id).FirstOrDefault();

            取消的活動.f聚會垃圾桶 = Convert.ToBoolean(聚會垃圾桶.刪除);

            _db.SaveChanges();
        }

        public void 核准參加者(int 聚會Id, int 參加者Id) 
        {
            某一個參加者(聚會Id, 參加者Id).f審核狀態 = Convert.ToBoolean(參加者審核狀態.通過);

            _db.SaveChanges();
        }

        private t參加者 某一個參加者(int 聚會Id, int 參加者Id)
        {
            t參加者 某個參加者 = _db.t參加者.Where(m => m.f會員Id == 參加者Id)
                .Where(m => m.f聚會Id == 聚會Id).FirstOrDefault();

            return 某個參加者;
        }
    }
}