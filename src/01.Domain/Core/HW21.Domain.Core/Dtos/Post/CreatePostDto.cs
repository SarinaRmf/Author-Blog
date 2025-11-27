using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Dtos.Post
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
