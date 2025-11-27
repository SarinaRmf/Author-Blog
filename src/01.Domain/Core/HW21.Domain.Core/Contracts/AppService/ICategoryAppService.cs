using HW21.Domain.Core.Dtos._common;
using HW21.Domain.Core.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.AppService
{
    public interface ICategoryAppService
    {
        ResultDto<bool> Add(CreateCategoryDto categoryDto);
        ResultDto<bool> Delete(int categoryId);
        ResultDto<bool> Update(GetCategoryDto categoryDto);
        List<GetCategoryDto> GetAll(int userId);
        GetCategoryDto GetById(int id);
    }
}
