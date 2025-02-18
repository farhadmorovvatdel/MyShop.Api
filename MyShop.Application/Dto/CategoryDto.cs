using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto
{
    public class CategoryDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }
        [MaxLength(150)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
