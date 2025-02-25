using Microsoft.AspNetCore.Components;
using MyShop.Application.Dto.Like;
using MyShop.Application.Dto.User;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.LikeServices
{
    public interface ILIkeService
    {
        Task LikePost(LikeDto like);
        Task<LIkeDetailDto> CheckExistsLike(LikeDto like);
        Task RemoveProductLike(LikeDto like);
        Task<int> GetAllLike(int ProductId);
    }
}
