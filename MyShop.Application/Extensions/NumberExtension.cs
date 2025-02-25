using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Extensions
{
    public static class NumberExtension
    {

        public static string ToPersianNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // تعریف معادل اعداد فارسی
            var englishNumbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var persianNumbers = new char[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };

            // جایگزینی اعداد انگلیسی با فارسی
            for (int i = 0; i < englishNumbers.Length; i++)
            {
                input = input.Replace(englishNumbers[i], persianNumbers[i]);
            }

            return input;
        }
       
    }

}
