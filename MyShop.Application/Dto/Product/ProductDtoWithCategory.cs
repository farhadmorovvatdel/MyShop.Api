using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Product
{
    public class ProductDtoWithCategory
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string? ProductImage { get; set; }
        public DateTime Created { get; set; }
    }
}
