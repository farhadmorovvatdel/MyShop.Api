using AutoMapper;
using MyShop.Application.Dto.Like;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.LikeServices
{
    public class LikeService : ILIkeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<LIkeDetailDto> CheckExistsLike(LikeDto like)
        {
            var ProductLike = await _likeRepository.CheckExistLike(like.UserId, like.ProductId);
            return _mapper.Map<LIkeDetailDto>(ProductLike);
        }

        public async Task<int> GetAllLike(int ProductId)
        {
            return await _likeRepository.GetAllLikes(ProductId);
        }

        public async Task LikePost(LikeDto like)
        {
            var likeporst = new Like()
            {
                UserId = like.UserId,
                ProductId = like.ProductId,
                IsLiked = true,
                CreatedDate = DateTime.Now,

            };
            await _likeRepository.AddLike(likeporst);
        }

        public async Task RemoveProductLike(LikeDto request)
        {
            var getlike = await _likeRepository.GetLike(request.UserId, request.ProductId);
            await _likeRepository.RemoveLike(request.UserId,getlike);
        }



        
    }
}
