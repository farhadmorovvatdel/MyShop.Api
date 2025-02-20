using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.OrderDetail
{
    public class ODetailDto
    {
        [Display(Name ="نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int ProductId { get; set; }
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
