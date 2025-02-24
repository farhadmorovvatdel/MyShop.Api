using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class DiscountCode
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Code { get; set; }

        [Range(0,100)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Amount { get; set; } 


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsValid()
        {
            return StartDate < EndDate;
       }
    }
}
