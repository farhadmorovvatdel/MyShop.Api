using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using MyShop.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositorservice
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MyShopContext _context;
        public CommentRepository(MyShopContext context)
        {
            _context = context;
        }

        public async Task AddComment(int UserId, Comment commnet)
        {
            await _context.comments.AddAsync(commnet);
            await _context.SaveChangesAsync();
        }

        public async Task DeletComment(int Id)
        {
            var comment=await GetCommentById(Id);
            _context.comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> GetComment(int CommentId,int UserId, int ProductId)
        {
            var Comment = await _context.comments.FirstOrDefaultAsync(c => c.Id == CommentId && c.UserId==UserId && c.ProductId == ProductId);
            return Comment;
        }

        public async Task<Comment> GetCommentById(int Id)
        {
         return await _context.comments.FindAsync( Id);
        }

        public async Task<int> GetCommentCount(int ProductId)
        {
          return await _context.comments.CountAsync(c=>c.ProductId == ProductId);
        }

        public async Task UPdateCommment(int UserId, Comment comment)
        {
             _context.comments.Update(comment);
             await _context.SaveChangesAsync();
        }
    }
}
