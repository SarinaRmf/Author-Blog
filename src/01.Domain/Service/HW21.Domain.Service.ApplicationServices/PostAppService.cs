using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.ApplicationServices
{
    public class PostAppService(IPostService postService) : IPostAppService
    {
        public ResultDto<bool> Add(CreatePostDto postDto)
        {
            return postService.Add(postDto);
        }

        public ResultDto<bool> Delete(int postId)
        {
            return postService.Delete(postId);
        }

        public List<GetPostDto> GetAll()
        {
            return postService.GetAll();
        }

        public GetPostDto? GetPost(int postId)
        {
            return postService.GetPost(postId);
        }

        public UpdatePostDto? GetUpdatePost(int postId)
        {
            return postService.GetUpdatePost(postId);
        }

        public List<GetPostDto> GetUserPosts(int userId)
        {
            return postService.GetUserPosts(userId);
        }

        public ResultDto<bool> Update(UpdatePostDto postDto)
        {
            return postService.Update(postDto);
        }
    }
}
