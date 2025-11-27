using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW21.Domain.Core.Contracts.Service
{
    public interface IFileService
    {
        string Upload(IFormFile file, string folder);
        void Delete(string fileName);
    }
}
