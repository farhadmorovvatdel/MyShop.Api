using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyShop.Application.Vm.Product
{
    public class ProductVm
    {
      //[Display(Name="نام محصول ")]
    //    [MaxLength(50)]
    //    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]

        public string Name { get; set; }

        //[Display(Name = "توضیحات محصول ")]
        //[MaxLength(150)]
        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Description { get; set; }
        //[Display(Name = " قیمت محصول ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[Range(0.01, 10000000.00, ErrorMessage = "قیمت محصول باید بین {1} و {2} باشد")]
        public decimal Price { get; set; }
        //[Display(Name = "تصویر محصول")]
        public string? ProductImage { get; set; }
        //[Display(Name = "دسته بندی مصحول")]
       
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int CategoryId { get; set; }




    }
}
