using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.User
{
    public class UpdateUserDto
    {
        [MaxLength(50)]
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }
        [MaxLength(100)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Family { get; set; }
        [Display(Name = "موبایل")]

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "شماره تلفن باید دقیقا 11 رقم باشد.")]
        public string PhoneNumber { get; set; }
        public string? Image { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile? UserImage { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }

    }
}
