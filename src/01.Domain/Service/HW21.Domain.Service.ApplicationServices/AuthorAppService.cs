using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Author;

namespace HW21.Domain.Service.ApplicationServices
{
    public class AuthorAppService(IAuthorService authorService) : IAuthorAppService
    {
        public ResultDto<AuthorLoginDto> Login(string username, string password)
        {
            return authorService.Login(username, password);
        }

        public ResultDto<bool> Register(CreateAuthorDto authorDto)
        {
            return authorService.Register(authorDto);
        }
    }
}
