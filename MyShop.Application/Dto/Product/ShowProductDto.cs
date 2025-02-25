using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Product
{
    public class ShowProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Price { get; set; }

        public string? ProductImage { get; set; }
        public string Created { get; set; }
    }
}
