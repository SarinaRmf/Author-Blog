using HW21.Domain.Core.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.Repository
{
    public interface IAuthorRepository
    {
        AuthorLoginDto Login(string username, string password);
        bool Register(CreateAuthorDto authorDto);
        bool UsernameExist(string username);
    }
}
