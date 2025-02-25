using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Extensions
{
    public static class PricExtension
    {
        public static string ToRial(this decimal amount)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:N0}" +" ریال", amount);
        }
    }
}
