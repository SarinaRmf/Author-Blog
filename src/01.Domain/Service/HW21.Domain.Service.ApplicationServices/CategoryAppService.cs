using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Contracts.Service;
using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Service.ApplicationServices
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public ResultDto<bool> Add(CreateCategoryDto categoryDto)
        {
            return categoryService.Add(categoryDto);
        }

        public ResultDto<bool> Delete(int categoryId)
        {
            return categoryService.Delete(categoryId);
        }

        public List<GetCategoryDto> GetAll(int userId)
        {
            return categoryService.GetAll(userId);
        }

        public GetCategoryDto GetById(int id)
        {
            return categoryService.GetById(id);
        }

        public ResultDto<bool> Update(GetCategoryDto categoryDto)
        {
            return categoryService.Update(categoryDto);
        }
    }
}
