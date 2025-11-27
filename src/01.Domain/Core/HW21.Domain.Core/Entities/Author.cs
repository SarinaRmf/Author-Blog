using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Entities
{
    public class Author : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
