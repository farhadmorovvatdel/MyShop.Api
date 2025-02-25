using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface ICommentRepository
    {
        Task AddComment(int UserId,Comment commnet);
        Task<Comment> GetComment(int CommentId,int UserId,int ProductId);
        Task UPdateCommment(int UserId,Comment comment);
        Task DeletComment(int Id);
        Task<Comment> GetCommentById(int Id);
        Task<int> GetCommentCount(int ProductId);
       
    }
}
