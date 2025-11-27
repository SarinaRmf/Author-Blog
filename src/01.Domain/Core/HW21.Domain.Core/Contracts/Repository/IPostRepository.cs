using HW21.Domain.Core.Dtos.Post;
using HW21.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.Repository
{
    public interface IPostRepository
    {
         List<GetPostDto> GetAll();
         List<GetPostDto> GetUserPosts(int userId);
         GetPostDto? GetPost(int postId);
         bool Add(CreatePostDto postDto);
         bool Delete(int postId);
         bool Update(UpdatePostDto postDto);
        string GetImageUrl(int postId);
        UpdatePostDto? GetUpdatePost(int postId);
    }
}

