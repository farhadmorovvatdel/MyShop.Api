using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.User
{
    public class ShowUserDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string? Image { get; set; }

        public bool IsActive { get; set; }

        public string CreatedDate { get; set; }


    }
}
