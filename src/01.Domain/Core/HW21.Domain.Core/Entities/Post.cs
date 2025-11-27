using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
