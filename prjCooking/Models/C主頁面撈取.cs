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

        public List<t聚會> 進行中聚會()
        {
            List<t聚會> 聚會List = db.Cooking查詢所有沒被刪除聚會List();
            List<t聚會> 進行中聚會List = new List<t聚會>();

            聚會List.Reverse();

            foreach (t聚會 聚會 in 聚會List)
            {
                if (聚會.f聚會狀態.Value == (int)聚會狀態.進行中)
                    進行中聚會List.Add(聚會);
            }

            return 進行中聚會List;
        }

        public List<t聚會> 未開始聚會()
        {
            List<t聚會> 聚會List = db.Cooking查詢所有沒被刪除聚會List();
            List<t聚會> 未開始聚會List = new List<t聚會>();

            聚會List.Reverse();

            foreach(t聚會 聚會 in 聚會List)
            {
                if (聚會.f聚會狀態.Value == (int)聚會狀態.可報名)
                    未開始聚會List.Add(聚會);
            }

            return 未開始聚會List;
        }

        public List<t聚會> 已結束聚會()
        {
            List<t聚會> 聚會List = db.Cooking查詢所有沒被刪除聚會List();
            List<t聚會> 已結束聚會List = new List<t聚會>();

            聚會List.Reverse();

            foreach (t聚會 聚會 in 聚會List)
            {
                if (聚會.f聚會狀態.Value == (int)聚會狀態.已結束)
                    已結束聚會List.Add(聚會);
            }

            return 已結束聚會List;
        }
    }
}