using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Dtos.Author
{
    public class CreateAuthorDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
