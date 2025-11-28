using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.Service
{
    public interface ICommentService
    {
        ResultDto<bool> Add(CreateCommentDto commentDto);
        List<GetCommentDto> GetComments(int postId);
        List<GetCommentDto> GetAcceptedComments(int postId);
        bool SetCommentStatus(int commentId, CommentStatus status);
    }
}
