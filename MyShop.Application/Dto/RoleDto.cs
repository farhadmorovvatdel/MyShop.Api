using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto
{
    public class RoleDto
    {
        [Display(Name="نام نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50,ErrorMessage ="نام نقش نمیتواند بیش از 50 کاراکتر باشد")]
        public string Name { get; set; }    
    }
}
