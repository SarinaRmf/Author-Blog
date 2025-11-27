using HW21.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Dtos.Category
{
    public class GetCategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
    }
}
