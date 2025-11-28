using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.Services
{
    public class CommentService(ICommentRepository _repo) : ICommentService
    {
        public ResultDto<bool> Add(CreateCommentDto commentDto)
        {
            var result = _repo.Create(commentDto);
            if (result)
            {
                return ResultDto<bool>.Success("نظر با موفقیت افزوده شد!");
            }
            return ResultDto<bool>.Failure("مشکلی در ثبت نظر رخ داد! دوباره تلاش کنید!");
        }

        public List<GetCommentDto> GetAcceptedComments(int postId)
        {
            return _repo.GetAcceptedComments(postId);
        }

        public List<GetCommentDto> GetComments(int postId)
        {
            return _repo.GetComments(postId);
        }
        public bool SetCommentStatus(int commentId, CommentStatus status)
        {
            return _repo.SetCommentStatus(commentId, status);
        }
    }
}
