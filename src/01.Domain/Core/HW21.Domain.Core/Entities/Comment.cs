using HW21.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string? Text { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float Rate { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public CommentStatus Status { get; set; }
    }
}
