using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.ApplicationServices
{
    public class CommentAppService(ICommentService commentService) : ICommentAppService
    {
        public ResultDto<bool> Add(CreateCommentDto commentDto)
        {
            return commentService.Add(commentDto);
        }

        public List<GetCommentDto> GetAcceptedComments(int postId)
        {
            return commentService.GetAcceptedComments(postId);
        }

        public List<GetCommentDto> GetComments(int postId)
        {
            return commentService.GetComments(postId);
        }
        public bool SetCommentStatus(int commentId, CommentStatus status)
        {
            return commentService.SetCommentStatus(commentId, status);
        }
    }
}