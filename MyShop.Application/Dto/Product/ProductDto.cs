using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Product
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }

        public string? ProductImage { get; set; }
        public string Created { get; set; }




    }
}
