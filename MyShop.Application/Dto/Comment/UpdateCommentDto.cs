using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Comment
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }

        public string CommentBody { get; set; }

        public int ProductId { get; set; }

    }
}
