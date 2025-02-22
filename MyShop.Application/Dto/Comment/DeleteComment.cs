using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Comment
{
    public class DeleteComment
    {
        public int ProductId { get; set; }
        public int CommentId { get; set; }
    }
}
