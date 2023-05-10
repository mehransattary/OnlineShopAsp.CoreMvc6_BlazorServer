using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IBlogService
{
    Task<bool> AddBlogAsync(Blog Blog, IFormFile? BlogImageMainFile, IFormFile? BlogImageSmallFile, string folder);
    Task<bool> UpdateBlogAsync(Blog Blog, IFormFile? BlogImageMainFile, IFormFile? BlogImageSmallFile, string folder);
}
