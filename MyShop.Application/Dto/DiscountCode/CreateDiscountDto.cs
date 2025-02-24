using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.DiscountCode
{
    public class CreateDiscountDto
    {
        [Display(Name ="کد")]
        [Required(ErrorMessage ="لطفا  کد{0} را وارد نمایید")]
        public string Code { get; set; }
        [Display(Name = "درصد /مقدار")]
        [Required(ErrorMessage = "لطفا  کد{0} را وارد نمایید")]
        public decimal Amount { get; set; }
        [Display(Name = "شروع تخفیف")]
        [Required(ErrorMessage = "لطفا  کد{0} را وارد نمایید")]
        public DateTime StartDate { get; set; }
        [Display(Name = "پایان تخفیف")]
        [Required(ErrorMessage = "لطفا  کد{0} را وارد نمایید")]
        public DateTime EndDate { get; set; }
    }
}
