using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjCooking.Models
{
    public class CDateTime合併
    {
        public static DateTime 合併(DateTime 年月日, DateTime 時分)
        {
            DateTime _合併 = new DateTime(年月日.Year, 年月日.Month, 年月日.Day, 時分.Hour, 時分.Minute, 0);

            return _合併;
        }
    }
}