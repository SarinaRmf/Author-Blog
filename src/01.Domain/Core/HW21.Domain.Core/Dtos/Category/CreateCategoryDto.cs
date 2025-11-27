using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Dtos.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string? Description { get; set; }
    }
}
