using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Extensions
{
    public static class DatePersian
    {
        public static string ShamsiDate(this DateTime date)
        {
            PersianCalendar pc= new PersianCalendar();
            return pc.GetYear(date).ToString("0000") + "/"+ pc.GetMonth(date).ToString("00") +"/"+ pc.GetDayOfMonth(date).ToString("00") ;
        }
    }
}
