using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsLiked { get; set; }

        #region Relations
        [ForeignKey("UserId")]  
        public User User { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        #endregion
    }
}
