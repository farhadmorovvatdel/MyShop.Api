using AutoMapper;
using MyShop.Application.Dto.Comment;
using MyShop.Application.Extensions;
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
            CreateMap<Comment,ShowCommentDetail>().ForMember(s=>s.CreatedDate,op=>op.MapFrom(t=>t.CreatedDate.ShamsiDate().ToPersianNumber()))
                ;
        }
    }
}
