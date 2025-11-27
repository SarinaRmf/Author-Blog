using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Dtos.Post
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
