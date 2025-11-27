using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Dtos.Author;
using HW21.Domain.Core.Entities;
using HW21.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Infra.Data.Repos.Ef
{
    public class AuthorRepository(AppDbContext _context) : IAuthorRepository
    {
        public AuthorLoginDto? Login(string username, string password)
        {
            return _context.Authors
                .AsNoTracking()
                .Where(a => a.Username == username && a.PasswordHash == password)
                .Select(a => new AuthorLoginDto
                {
                    UserId = a.Id ,
                    UserName = a.Username,
                })
                .FirstOrDefault();
        }

        public bool Register(CreateAuthorDto authorDto)
        {
            var entity = new Author()
            {
                PasswordHash = authorDto.Password,
                Username = authorDto.Username,
                Email = authorDto.Email,
                CreatedAt = DateTime.Now,
            };
            _context.Authors.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool UsernameExist(string username)
        {

            return _context.Authors.Any(u => u.Username == username);

        }

    }
}
