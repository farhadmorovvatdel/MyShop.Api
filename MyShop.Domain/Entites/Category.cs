using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength (50)]
        
        public string? Description { get; set; }

        public List<Product> Products { get; set; } =new List<Product>();
    }
}
