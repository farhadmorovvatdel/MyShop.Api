using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entites
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Family { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }=false;

        public string ?ImageUrl { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        #region relations
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }


        public int RoleId { get; set; }

        public List<Like> Like { get; set; }=new List<Like>();
        public List<Comment> Comment { get; set; }=new List<Comment>();
        public List<Rate> Rate { get; set; }=new List<Rate>();

        #endregion


    }
}
