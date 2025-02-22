using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface ILikeRepository
    {
        Task AddLike(Like like);
        Task<bool> CheckExistLikebool(int UserId,int ProductId);
        Task<Like> CheckExistLike(int UserId,int ProductId);
        Task RemoveLike(int UserId,Like like);
        Task<Like> GetLike(int UserId,int ProductId);
    }
}
