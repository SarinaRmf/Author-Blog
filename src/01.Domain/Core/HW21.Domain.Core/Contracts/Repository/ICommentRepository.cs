using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.Repository
{
    public interface ICommentRepository
    {
        bool Create(CreateCommentDto commentDto);
        List<GetCommentDto> GetComments(int postId);
        List<GetCommentDto> GetAcceptedComments(int postId);
        bool SetCommentStatus(int commentId, CommentStatus status);
    }
}
