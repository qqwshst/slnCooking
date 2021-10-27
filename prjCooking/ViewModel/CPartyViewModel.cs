using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjCooking.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjCooking.ViewModel
{
    public class CPartyViewModel
    {
        public t聚會 party { get; set; } = null;
        public t會員 party_member { get; set; } = null;
        public t建議食材 party_food { get; set; } = null;
        public HttpPostedFileBase image { get; set; }

        public CPartyViewModel()
        {
            this.party = new t聚會();
            this.party_member = new t會員();
        }

        public int f聚會Id { get; set; }
        public int f主辦人 { get; set; }
        public string f聚會名稱 { get; set; }
        public string f聚會內容 { get; set; }
        public string f聚會照片 { get; set; }

        public System.DateTime f聚會日期
        {
            get { return this.party.f聚會建立日期; }
            set { this.party.f聚會建立日期 = value; }
        }
        public System.DateTime f聚會開始時間
        {
            get { return this.party.f聚會開始時間; }
            set { this.party.f聚會開始時間 = value; }
        }
        public Nullable<System.DateTime> f聚會結束時間
        {
            get { return this.party.f聚會結束時間; }
            set { this.party.f聚會結束時間 = value; }
        }
        public Nullable<int> f名額
        {
            get { return this.party.f名額; }
            set { this.party.f名額 = value; }
        }
        public string f聚會軟體
        {
            get { return this.party.f聚會軟體; }
            set { this.party.f聚會軟體 = value; }
        }
        public string f聚會軟體URL
        {
            get { return this.party.f聚會軟體URL; }
            set { this.party.f聚會軟體URL = value; }
        }
        public string f聚會關鍵字
        {
            get { return this.party.f聚會關鍵字; }
            set { this.party.f聚會關鍵字 = value; }
        }
        public string f聚會通訊軟體
        {
            get { return this.party.f聚會通訊軟體; }
            set { this.party.f聚會通訊軟體 = value; }
        }
        public string f聚會通訊軟體帳號
        {
            get { return this.party.f聚會通訊軟體帳號; }
            set { this.party.f聚會通訊軟體帳號 = value; }
        }
        public Nullable<int> f聚會狀態
        {
            get { return this.party.f聚會狀態; }
            set { this.party.f聚會狀態 = value; }
        }

        public Nullable<bool> f聚會垃圾桶
        {
            get { return this.party.f聚會垃圾桶; }
            set { this.party.f聚會垃圾桶 = value; }
        }

        public System.DateTime f聚會建立日期
        {
            get { return this.party.f聚會建立日期; }
            set { this.party.f聚會建立日期 = value; }
        }

    }
}