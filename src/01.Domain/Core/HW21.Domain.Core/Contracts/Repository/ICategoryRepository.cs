using HW21.Domain.Core.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.Repository
{
    public interface ICategoryRepository
    {
        bool Add(CreateCategoryDto categoryDto);
        List<GetCategoryDto> GetAll(int userId);
        GetCategoryDto GetById(int id);
        bool Update(GetCategoryDto CategoryDto);
        bool Delete(int categoryId);
        bool NameIsExist(string name, int AuthorId);
        bool IsExist(int categoryId);
    }
}
