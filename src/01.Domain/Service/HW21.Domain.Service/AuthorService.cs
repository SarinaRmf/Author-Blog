using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Author;
using HW21.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.Services
{
    public class AuthorService(IAuthorRepository _repo) : IAuthorService
    {
        public ResultDto<AuthorLoginDto> Login(string username, string password)
        {
            var result = _repo.Login(username, password.ToMd5Hex());
            if (result is null)
            {
                return new ResultDto<AuthorLoginDto> { IsSuccess = false, Message = "نام کاربری یا رمز عبور اشتباه است" };
            }
            return new ResultDto<AuthorLoginDto> { IsSuccess = true, Message = "لاگین با موفقیت انجام شد", Data = result };
        }

        public ResultDto<bool> Register(CreateAuthorDto authorDto)
        {
            if (_repo.UsernameExist(authorDto.Username))
            {

                return new ResultDto<bool> { IsSuccess = false, Message = "نام کاربری موجود می باشد" };
            }

            authorDto.Password = authorDto.Password.ToMd5Hex();
            if (_repo.Register(authorDto))
            {
                return new ResultDto<bool> { IsSuccess = true, Message = "ثبت نام با موفقیت انجام شد" };
            }
            return new ResultDto<bool> { IsSuccess = false, Message = "ثبت نام انجام نشد" };
        }
    }
}
