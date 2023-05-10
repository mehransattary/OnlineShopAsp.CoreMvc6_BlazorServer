using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IProductService
{
    Task<bool> AddProductAsync(Product Product, IFormFile? ProductImageMainFile, IFormFile? ProductImageSmallFile, string folder);
    Task<bool> UpdateProductAsync(Product Product, IFormFile? ProductImageMainFile, IFormFile? ProductImageSmallFile, string folder);
}
