using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface ICategoryService
{
    Task<bool> AddCategoryAsync(Category Category, IFormFile? CategoryImageFile, string folder);
    Task<bool> UpdateCategoryAsync(Category Category, IFormFile? CategoryImageFile, string folder);
}
