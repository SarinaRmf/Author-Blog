using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.AppService
{
    public interface IPostAppService
    {
        List<GetPostDto> GetAll();
        List<GetPostDto> GetUserPosts(int userId);
        GetPostDto? GetPost(int postId);
        ResultDto<bool> Add(CreatePostDto postDto);
        ResultDto<bool> Delete(int postId);
        ResultDto<bool> Update(UpdatePostDto postDto);
        UpdatePostDto? GetUpdatePost(int postId);
    }
}
