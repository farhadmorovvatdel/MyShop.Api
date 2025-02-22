using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using MyShop.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositorservice
{
    public class LikeRepository : ILikeRepository
    {
        private readonly MyShopContext _context;
        public LikeRepository(MyShopContext context)
        {
            _context = context;
        }

        public async Task AddLike(Like like)
        {
            await _context.likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task<Like> CheckExistLike(int UserId, Like like)
        {
            var ExistLike = await _context.likes.SingleOrDefaultAsync(l => l.UserId == UserId && l.ProductId == like.ProductId && l.IsLiked == false);
            return ExistLike;
        }

        public async Task<Like> CheckExistLike(int UserId, int ProductId)
        {
            return await _context.likes.SingleOrDefaultAsync(l => l.UserId == UserId && l.ProductId == ProductId && l.IsLiked == true);
        }

        public async Task<bool> CheckExistLikebool(int UserId, int ProductId)
        {
            return await _context.likes.AnyAsync(l=>l.UserId==UserId && l.ProductId==ProductId && l.IsLiked==false);
        }

        public async Task<Like> GetLike(int UserId, int ProductId)
        {
           return await _context.likes.SingleOrDefaultAsync(l=>l.UserId==UserId&&l.ProductId==ProductId);
        }

        public async Task RemoveLike(int UserId, Like like)
        {
             _context.likes.Remove(like);
            await _context.SaveChangesAsync();
        }
    }


}

