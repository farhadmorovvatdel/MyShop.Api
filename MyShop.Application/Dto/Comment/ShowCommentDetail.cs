using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Comment
{
    public class ShowCommentDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
        public string CreatedDate { get; set; }
    }
}
