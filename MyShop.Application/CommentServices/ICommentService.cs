using MyShop.Application.Dto.Comment;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.CommentServices
{
    public interface ICommentService
    {
        Task<ShowCommentDetail> AddComment(int UserId, CreateCommentDto request);
        
        Task<ShowCommentDetail> UpdateComment(int UserId, UpdateCommentDto request);

        Task DeleteComment(int CommentId);
        Task<ShowCommentDetail> GetCommentById(int CommentId, int UserId,int ProductId);
        Task<int> ProductComments(int ProductId);
    }
}
