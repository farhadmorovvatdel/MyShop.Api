using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        [Range(0,5)]
        public float RateNumber { get; set; }
        public int UserId { get; set; }

        public int ProductId { get; set; }

        #region Realtions

        [ForeignKey("UserId")]
        public User user { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }

        #endregion
    }
}
