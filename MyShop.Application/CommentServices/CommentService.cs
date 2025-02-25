using AutoMapper;
using MyShop.Application.Dto.Comment;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;   
        }
        public async Task<ShowCommentDetail> AddComment(int UserId, CreateCommentDto request)
        {
            var comment = new Comment
            {
                ProductId = request.ProductId,
                CommentBody = request.CommentBody,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                UserId = UserId,

            };
            await _commentRepository.AddComment(UserId,comment);
            return _mapper.Map<ShowCommentDetail>(comment);
        }

        public async Task DeleteComment(int CommentId)
        {
          await _commentRepository.DeletComment(CommentId);
        }

        public async Task<ShowCommentDetail> GetCommentById(int CommentId, int UserId, int ProductId)
        {
            var comment= await _commentRepository.GetComment(CommentId,UserId, ProductId);
            return _mapper.Map<ShowCommentDetail>(comment);
        }

        public async Task<int> ProductComments(int ProductId)
        {
           return  await _commentRepository.GetCommentCount(ProductId);
        }

        public async Task<ShowCommentDetail> UpdateComment(int UserId, UpdateCommentDto request)
        {
            var comment =await _commentRepository.GetComment(request.Id,UserId, request.ProductId);
            comment.CommentBody = request.CommentBody;
            comment.UpdatedDate = DateTime.Now;
            comment.UserId = UserId;
            await _commentRepository.UPdateCommment(UserId,comment);
            return _mapper.Map<ShowCommentDetail>(comment);

        }
        
    }
}
