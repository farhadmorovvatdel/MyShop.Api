using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Rate
{
    public class ShowRateDto
    {
        public int Id { get; } 

        public int ProductId { get; }

        public int UserId { get; }

        public float RateNumber { get; }
    }

}
