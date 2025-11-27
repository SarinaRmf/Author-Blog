using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Post>? Post { get; set; }

    }
}
