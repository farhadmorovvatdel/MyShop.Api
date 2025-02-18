using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto
{
    public class UserDto
    {
        [MaxLength(50)]
        [Display(Name="نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Family { get; set; }
        
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "موبایل")]
        
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "شماره تلفن باید دقیقا 11 رقم باشد.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیستند")]
        public string ConfirmPassword { get; set; }

        

        
    }
}
