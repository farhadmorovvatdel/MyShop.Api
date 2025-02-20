using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.OrderDetail
{
    public class SHowOrderDetail
    {
        public int UserId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }   

        public decimal Price { get; set; }  

        
    }
}
