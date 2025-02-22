using AutoMapper;
using MyShop.Application.Dto.Comment;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Mapping
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment,ShowCommentDetail>();
        }
    }
}
