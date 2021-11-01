using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjCooking.Models
{
    public class C主頁面撈取
    {
        private dbCookingEntities db;

        public C主頁面撈取()
        {
            db = new dbCookingEntities();
        }

        public List<t聚會> 所有聚會()
        {
            List<t聚會> 聚會List = db.Cooking查詢所有沒被刪除聚會List();
            聚會List.Reverse();

            return 聚會List;
        }


    }
}