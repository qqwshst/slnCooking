using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjCooking.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjCooking.ViewModel
{
    public class CFoodViewModel
    {
        public t建議食材 party_food { get; set; } = null;
        public CFoodViewModel()
        {
        
            this.party_food = new t建議食材();
            
        }
        public int f聚會Id
        {
            get { return this.party_food.f聚會Id; }
            set { this.party_food.f聚會Id = value; }
        }
        public string f食材名稱
        {
            get { return this.party_food.f食材名稱; }
            set { this.party_food.f食材名稱 = value; }
        }
        public Nullable<int> f數量
        {
            get { return this.party_food.f數量; }
            set { this.party_food.f數量 = value; }
        }
        public string f單位
        {
            get { return this.party_food.f單位; }
            set { this.party_food.f單位 = value; }
        }
    }
}