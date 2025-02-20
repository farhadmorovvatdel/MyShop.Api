using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey(nameof(order))]
        public int orderId { get; set; }
        [ForeignKey(nameof(product))]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        #region 
        public Order order { get; set; }

        public Product product { get; set; }
        #endregion
    }
}
