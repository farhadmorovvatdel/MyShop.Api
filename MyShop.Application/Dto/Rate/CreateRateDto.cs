using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Rate
{
    public class CreateRateDto
    {
        [Required]
        public int ProductId { get; set; }
        [Range(0,5)]
        [Required]
        public float Ratenumber { get; set; }
    }
}
