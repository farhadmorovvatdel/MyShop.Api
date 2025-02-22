using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Dto.Comment
{
   public class CreateCommentDto
    {
        [Required] 
        public int ProductId { get; set; }
        [Required(ErrorMessage ="لطفا نظر خود را وارد نمایید")]
        public string CommentBody { get; set; }

    }
}
