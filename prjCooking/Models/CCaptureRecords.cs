﻿// 撈取報名、舉辦的活動
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

        public List<CCaptureMeetInfo> 撈取報名記錄(int? memberId, int? sort, int? statu)
        {
            List<CCaptureMeetInfo> data = db.t參加者.Where(m => m.f會員Id == memberId.Value)
                .OrderBy(m => m.f參加者建立日期)
                .Select(m => new CCaptureMeetInfo { 
                    主辦人 = m.t聚會.t會員.f會員姓名,
                    聚會名稱 = m.t聚會.f聚會名稱,
                    聚會日期 = m.t聚會.f聚會日期,
                    聚會狀態Number = m.t聚會.f聚會狀態.Value,
                    Is評價 = m.t評價.Where(t => t.f聚會Id == m.f聚會Id).Count() > 0 ? true : false
                }).ToList();

            Sort(data, sort, statu);

            return data;
        }

        private void 選擇聚會狀態(List<CCaptureMeetInfo> data, int statu)
        {
            switch (statu)
            {
                case (int)聚會狀態.可報名:
                    data = data.Where(info => 聚會狀態.可報名.CompareTo(info.聚會狀態Number.Value) == 0).ToList();
                    break;
                case (int)聚會狀態.進行中:
                    data = data.Where(info => 聚會狀態.進行中.CompareTo(info.聚會狀態Number.Value) == 0).ToList();
                    break;
                case (int)聚會狀態.已結束:
                    data = data.Where(info => 聚會狀態.已結束.CompareTo(info.聚會狀態Number.Value) == 0).ToList();
                    break;
            }
        }

        private void Sort(List<CCaptureMeetInfo> data, int? sortNumber, int? statu)
        {
            if(data.Count > 0)
            {
                // 排序 0新 1舊
                if (sortNumber.Value == 1)
                {
                    data.Reverse();
                }

                // 狀態 3 全部
                if (statu.Value < 3)
                    選擇聚會狀態(data, statu.Value);
            }
        }

        public List<CCaptureMeetInfo> 撈取主辦記錄(int? memberId, int? sort)
        {
            List<CCaptureMeetInfo> data = db.t聚會.Where(meet => meet.f主辦人 == memberId.Value)
                .OrderBy(meet => meet.f聚會建立日期)
                .Select(meet => new CCaptureMeetInfo { 
                    主辦人 = meet.t會員.f會員姓名,
                    聚會名稱 = meet.f聚會名稱,
                    聚會日期 = meet.f聚會日期,
                    聚會狀態Number = meet.f聚會狀態.Value,
                    人數上限 = meet.f名額.Value,
                    目前人數 = meet.t參加者.Where(t => t.f聚會Id == meet.f聚會Id).Count()
                }).ToList();

            Sort(data, sort, null);

            return data;
        }
    }
}