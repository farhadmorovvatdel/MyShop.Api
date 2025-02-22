using Microsoft.AspNetCore.Antiforgery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Like
{
    public class LikeDto
    {
        [Required]

        public int UserId { get; set; }
        public int ProductId { get; set; }

       
    }
}
