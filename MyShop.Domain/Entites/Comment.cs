using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]    
        public string CommentBody { get; set; } 


        public DateTime CreatedDate { get; set; }=DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        #region #relations
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int ProductId { get; set; }
        #endregion
    }
}
