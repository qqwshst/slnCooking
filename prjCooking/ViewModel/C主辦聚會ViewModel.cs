using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjCooking.Models;

namespace prjCooking.ViewModel
{
    public class C主辦聚會ViewModel
    {
        public t聚會 主辦聚會資訊 { get; set; }
        public HttpPostedFileBase 上傳的圖片 { get; set; }
        
        public C主辦聚會ViewModel()
        {
            主辦聚會資訊 = new t聚會();
            //食材名稱List = new List<string>();
            //食材單位List = new List<string>();
            //食材數量List = new List<int>();
        }

        public string 聚會名稱 
        {
            get
            {
                return 主辦聚會資訊.f聚會名稱;
            }
            set
            {
                主辦聚會資訊.f聚會名稱 = value;
            }
        }
        public string 聚會內容
        {
            get
            {
                return 主辦聚會資訊.f聚會名稱;
            }
            set
            {
                主辦聚會資訊.f聚會名稱 = value;
            }
        }
        public DateTime 聚會日期
        {
            get
            {
                return 主辦聚會資訊.f聚會日期;
            }
            set
            {
                主辦聚會資訊.f聚會日期 = value;
            }
        }
        public System.DateTime 聚會開始時間 { get; set; }
        public System.DateTime 聚會結束時間 { get; set; }
        public Nullable<int> 名額 
        {
            get
            {
                return 主辦聚會資訊.f名額;
            }
            set
            {
                主辦聚會資訊.f名額 = value;
            }
        }
        public string 聚會軟體 
        {
            get
            {
                return 主辦聚會資訊.f聚會軟體;
            }
            set
            {
                主辦聚會資訊.f聚會軟體 = value;
            }
        }
        public string 聚會軟體URL 
        {
            get
            {
                return 主辦聚會資訊.f聚會軟體URL;
            }
            set
            {
                主辦聚會資訊.f聚會軟體URL = value;
            }
        }
        public string 聚會關鍵字 
        {
            get
            {
                return 主辦聚會資訊.f聚會關鍵字;
            }
            set
            {
                主辦聚會資訊.f聚會關鍵字 = value;
            }
        }
        public string 聚會通訊軟體 
        {
            get
            {
                return 主辦聚會資訊.f聚會通訊軟體;
            }
            set
            {
                主辦聚會資訊.f聚會通訊軟體 = value;
            }
        }
        public string 聚會通訊軟體帳號 
        {
            get
            {
                return 主辦聚會資訊.f聚會通訊軟體帳號;
            }
            set
            {
                主辦聚會資訊.f聚會通訊軟體帳號 = value;
            }
        }

        public List<string> 食材名稱List { get; set; }
        public List<int?> 食材數量List { get; set; }
        public List<string> 食材單位List { get; set; }
    }
}