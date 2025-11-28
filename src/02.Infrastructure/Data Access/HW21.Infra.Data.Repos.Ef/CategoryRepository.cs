using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Dtos.Category;
using HW21.Domain.Core.Entities;
using HW21.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Infra.Data.Repos.Ef
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public bool Add(CreateCategoryDto categoryDto)
        {
            var entity = new Category()
            {
                AuthorId = categoryDto.AuthorId,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
            _context.Categories.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId).ExecuteDelete() > 0;
        }

        public List<GetCategoryDto> GetAll(int userId)
        {
            return _context.Categories
                .AsNoTracking()
                .Where(c=> c.AuthorId == userId)
                .Select(c => new GetCategoryDto
                {
                    AuthorId=c.AuthorId,
                    Name=c.Name,
                    Description=c.Description,
                    CreatedAt = c.CreatedAt,
                    Id = c.Id
                })
                .ToList();
        }

        public GetCategoryDto? GetById(int Id)
        {
            return _context.Categories
                .AsNoTracking()
                .Where(c => c.Id  == Id)
                .Select(c => new GetCategoryDto
                {
                    AuthorId = c.AuthorId,
                    Name = c.Name,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                })
                .FirstOrDefault();
        }

        public bool IsExist(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public bool NameIsExist(string name, int AuthorId)
        {
            return _context.Categories.Any(c => c.Name == name && c.AuthorId == AuthorId);
        }

        public bool Update(GetCategoryDto CategoryDto)
        {
            var result = _context.Categories
                .Where(c => c.Id == CategoryDto.Id)
                .ExecuteUpdate(setters => setters
                .SetProperty(c => c.Name, CategoryDto.Name)
                .SetProperty(c => c.Description, CategoryDto.Description)
                .SetProperty(c => c.UptatedAt, DateTime.Now));

            return true;
        }
    }
}
