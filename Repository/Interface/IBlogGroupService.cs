using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IBlogGroupService
{
    Task<bool> AddBlogGroupAsync(BlogGroup BlogGroup, IFormFile? BlogGroupImageFile, string folder);
    Task<bool> UpdateBlogGroupAsync(BlogGroup BlogGroup, IFormFile? BlogGroupImageFile, string folder);
}
