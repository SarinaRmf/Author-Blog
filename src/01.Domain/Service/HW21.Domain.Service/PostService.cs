using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.Services
{
    public class PostService(IPostRepository _repo, IFileService fileService) : IPostService
    {
        public ResultDto<bool> Add(CreatePostDto postDto)
        {
            postDto.ImagePath = fileService.Upload(postDto.ImageFile, "images");
            var result = _repo.Add(postDto);
            if (result)
            {
                return ResultDto<bool>.Success("پست با موفقیت افزوده شد");
            }
            return ResultDto<bool>.Failure("خطا در افزودن پست!");
        }

        public ResultDto<bool> Delete(int postId)
        {
            var result = _repo.Delete(postId);
            if (result)
            {
                return ResultDto<bool>.Success("پست با موفقیت حذف شد");
            }
            return ResultDto<bool>.Failure("خطا در حذف پست!");
        }

        public List<GetPostDto> GetAll()
        {
            return _repo.GetAll();
        }

        public GetPostDto? GetPost(int postId)
        {
            return _repo.GetPost(postId);
        }

        public UpdatePostDto? GetUpdatePost(int postId)
        {
            return _repo.GetUpdatePost(postId);
        }

        public List<GetPostDto> GetUserPosts(int userId)
        {
            return _repo.GetUserPosts(userId);
        }

        public ResultDto<bool> Update(UpdatePostDto postDto)
        {
            if (postDto.ImageFile is not null)
            {
                var currentImageUrl = _repo.GetImageUrl(postDto.Id);

                if (!string.IsNullOrEmpty(currentImageUrl))
                {
                    fileService.Delete(currentImageUrl);
                    postDto.ImagePath = fileService.Upload(postDto.ImageFile, "images");
                }
            }
            var result = _repo.Update(postDto);
            if (result)
            {
                return ResultDto<bool>.Success("پست با موفقیت ویرایش شد");
            }
            return ResultDto<bool>.Failure("خطا در ویرایش پست!");
        }
    }
}
