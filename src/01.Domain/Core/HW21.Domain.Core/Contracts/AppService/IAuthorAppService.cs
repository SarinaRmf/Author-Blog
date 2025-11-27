using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.AppService
{
    public interface IAuthorAppService
    {
        ResultDto<AuthorLoginDto> Login(string username, string password);
        ResultDto<bool> Register(CreateAuthorDto authorDto);
    }
}
