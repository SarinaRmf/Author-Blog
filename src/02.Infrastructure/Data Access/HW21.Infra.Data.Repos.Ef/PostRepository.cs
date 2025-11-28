using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Dtos.Post;
using HW21.Domain.Core.Entities;
using HW21.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW21.Infra.Data.Repos.Ef
{
    public class PostRepository(AppDbContext _context) : IPostRepository
    {
        public List<GetPostDto> GetAll()
        {
            return _context.Posts
                .AsNoTracking()
                .Select(p => new GetPostDto
            {
                Id = p.Id,
                Title = p.Title,
                CategoryName = p.Category.Name,
                AuthorName = p.Author.Username,
                Description = p.Description.Length > 200 ? p.Description.Substring(0,200) : p.Description,
                ImagePath = p.ImagePath,
                CreatedAt = p.CreatedAt
            }).OrderByDescending(p => p.CreatedAt)
             .ToList();
        }

        public List<GetPostDto> GetUserPosts(int userId) {

            return _context.Posts
                .AsNoTracking()
                .Where(p => p.AuthorId == userId)
                .Select(p => new GetPostDto
            {
                Id = p.Id,
                Title = p.Title,
                CategoryName = p.Category.Name,
                AuthorName = p.Author.Username,
                Description = p.Description.Length > 200 ? p.Description.Substring(0, 200) : p.Description,
                ImagePath = p.ImagePath,
                CreatedAt = p.CreatedAt

            }).OrderByDescending(p => p.CreatedAt)
              .ToList();
        }

        public GetPostDto? GetPost(int postId) //edit detail
        {
            return _context.Posts
                .AsNoTracking()
                .Where(p => p.Id == postId)
                .Select(p => new GetPostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    CategoryName = p.Category.Name,
                    AuthorName = p.Author.Username,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                    CreatedAt = p.CreatedAt

                }).FirstOrDefault();
        }

        public bool Add(CreatePostDto postDto)
        {
            var entity = new Post()
            {
                AuthorId = postDto.AuthorId,
                Title = postDto.Title,
                Description = postDto.Description,
                CategoryId = postDto.CategoryId,
                ImagePath = postDto.ImagePath,
                CreatedAt = DateTime.Now,
                
            };
            _context.Posts.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int postId)
        {
            return _context.Posts.Where(p => p.Id == postId).ExecuteDelete() > 0;
        }

        public bool Update(UpdatePostDto postDto)
        {
            try
            {
                var post = _context.Posts
                .FirstOrDefault(p => p.Id == postDto.Id);

                if (post is not null)
                {
                    post.CategoryId = postDto.CategoryId;
                    post.Title = postDto.Title;
                    post.Description = postDto.Description;
                    post.UptatedAt = DateTime.Now;
                    post.ImagePath = string.IsNullOrEmpty(postDto.ImagePath) ? post.ImagePath : postDto.ImagePath;

                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public string GetImageUrl(int postId)
        {
            var imgAddress = _context.Posts
                .Where(p => p.Id == postId)
                .Select(p => p.ImagePath)
                .FirstOrDefault();


            return imgAddress;
        }
        public UpdatePostDto? GetUpdatePost(int postId)
        {
            return _context.Posts
                .AsNoTracking()
                .Where(p => p.Id == postId)
                .Select(p => new UpdatePostDto
                {
                    Title = p.Title,
                    CategoryId = p.CategoryId,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                    Id = p.Id
                }).FirstOrDefault();
                
        }
        
    }
}
