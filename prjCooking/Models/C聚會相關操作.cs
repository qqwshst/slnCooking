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
            /*var tempList = (from 參加者 in _db.t參加者
                       where 參加者.f會員Id == 會員Id.Value
                       && 參加者.f聚會Id == 聚會Id
                       select 參加者).FirstOrDefault();*/
            List<t參加者> tempList = _db.t參加者.Where(m => m.f會員Id == 會員Id)
                .Where(m => m.f聚會Id == 聚會Id).FirstOrDefault();

            foreach(t參加者 參加者 in tempList)
            {
                參加者.f報名 = true;
            }

            _db.SaveChanges();
        }

        public void 取消活動(int 聚會Id)
        {
            List<t聚會> temp = _db.t聚會.Where(聚會 => 聚會.f聚會Id == 聚會Id).FirstOrDefault();

            foreach(t聚會 聚會 in temp)
            {
                聚會.f聚會垃圾桶 = (int)聚會垃圾桶.刪除;
            }

            _db.SaveChanges();
        }
    }
}