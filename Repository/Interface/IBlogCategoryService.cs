using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IBlogCategoryService
{
    Task<bool> AddBlogCategoryAsync(BlogCategory BlogCategory, IFormFile? BlogCategoryImageFile, string folder);
    Task<bool> UpdateBlogCategoryAsync(BlogCategory BlogCategory, IFormFile? BlogCategoryImageFile, string folder);
}
