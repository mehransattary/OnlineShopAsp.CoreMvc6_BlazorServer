using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IBrandService
{
    Task<bool> AddBrandAsync(Brand Brand, IFormFile? BrandImageFile, string folder);
    Task<bool> UpdateBrandAsync(Brand Brand, IFormFile? BrandImageFile, string folder);
}
