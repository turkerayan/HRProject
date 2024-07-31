using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Abstractions
{
    public interface IFileHelper
    {
        string Add(IFormFile file, string? userId, string? root = null);
        void Delete(IFormFile file, string path, string fileName);
        string Update(IFormFile file,  string? userId, string? root = null);
        
    }
}
