using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; } 

        public bool IsPay { get; set;}

        #region relations
        public List<OrderDetail> Deatils { get; set; }
        #endregion
        public decimal OrderPriceTotal()
        {
            return Deatils.Sum(o=>o.Price* o.Quantity);
        }
    }
}
