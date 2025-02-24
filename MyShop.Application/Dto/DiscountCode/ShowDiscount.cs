using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.DiscountCode
{
    public class ShowDiscount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
