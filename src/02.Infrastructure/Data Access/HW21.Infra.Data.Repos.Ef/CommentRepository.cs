using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Entities;
using HW21.Domain.Core.Enums;
using HW21.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Infra.Data.Repos.Ef
{
    public class CommentRepository(AppDbContext _context) : ICommentRepository
    {
        public bool Create(CreateCommentDto commentDto)
        {
            var entity = new Comment()
            {
                CreatedAt = DateTime.Now,
                Email = commentDto.Email,
                FirstName = commentDto.FirstName,
                LastName = commentDto.LastName,
                PostId = commentDto.PostId,
                Rate = commentDto.Rate,
                Status = Domain.Core.Enums.CommentStatus.Pending,
                Text = commentDto.Text,
            };
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public List<GetCommentDto> GetComments(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId)
                .AsNoTracking()
                .Select(c => new GetCommentDto
                {
                    Email = c.Email,
                    FirstName = c.FirstName,    
                    LastName = c.LastName,
                    Id = c.Id,
                    Rate = c.Rate,
                    Status = c.Status,
                    Text = c.Text,
                    PostId = c.PostId
                    
                })
                .ToList();
        }

        public List<GetCommentDto> GetAcceptedComments(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId &&
                c.Status == Domain.Core.Enums.CommentStatus.Accepted)
               .AsNoTracking()
               .Select(c => new GetCommentDto
               {
                   Email = c.Email,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   Id = c.Id,
                   Rate = c.Rate,
                   Status = c.Status,
                   Text = c.Text
               })
               .ToList();
        }
        public bool SetCommentStatus(int commentId, CommentStatus status)
        {
            var result = _context.Comments
                .Where(c => c.Id == commentId)
                .ExecuteUpdate(setters => setters
                .SetProperty(c => c.Status, status));

            return true;
        }
    }
}
