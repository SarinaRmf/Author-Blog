using HW21.Domain.Core.Contracts.Repository;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Category;
using HW21.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.Services
{
    public class CategoryService(ICategoryRepository _repo) : ICategoryService
    {
        public ResultDto<bool> Add(CreateCategoryDto categoryDto)
        {
            if (_repo.NameIsExist(categoryDto.Name, categoryDto.AuthorId)) {

                return ResultDto<bool>.Failure("دسته بندی موجود است!");
            }
            var result = _repo.Add(categoryDto);
            if (result)
            {
                return ResultDto<bool>.Success("دسته بندی با موفقیت اضافه شد");
            }
            return ResultDto<bool>.Failure("دسته بندی اضافه نشد! دوباره تلاش کنید!");
        }

        public ResultDto<bool> Delete(int categoryId)
        {
            if (!_repo.IsExist(categoryId)) {
                return ResultDto<bool>.Failure("دسته بندی وجود ندارد!");
            }
            var result = _repo.Delete(categoryId);
            if (result) {
                return ResultDto<bool>.Success("دسته بندی با موفقیت حذف شد.");
            }
            return ResultDto<bool>.Failure("خطا در حذف دسته بندی! دوباره تلاش کنید");
        }

        public List<GetCategoryDto> GetAll(int userId)
        {
            return _repo.GetAll(userId);
        }

        public GetCategoryDto GetById(int id)
        {
            return _repo.GetById(id);
        }

        public ResultDto<bool> Update(GetCategoryDto categoryDto)
        {
            if (!_repo.IsExist(categoryDto.Id))
            {
                return ResultDto<bool>.Failure("دسته بندی وجود ندارد!");
            }
            var result = _repo.Update(categoryDto);
            if (result)
            {
                return ResultDto<bool>.Success("دسته بندی با موفقیت ویرایش شد.");
            }
            return ResultDto<bool>.Failure("خطا در ویرایش دسته بندی! دوباره تلاش کنید");
        }
    }
}
