using Common;
using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public class ProductService: IProductService
{
    private readonly AppDbContext context;
    public ProductService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddProductAsync(Product Product, IFormFile? ProductImageMainFile, IFormFile? ProductImageSmallFile, string folder)
    {
        try
        {
            if (ProductImageMainFile != null)
            {
                #region Save ProductImageMain
                string pathmain = Images.AddImage(ProductImageMainFile, folder);
                Product.ProductImageMain = pathmain; 
                #endregion
            }
            if (ProductImageSmallFile != null)
            {
                #region Save ProductImageSmall  
                string pathsmall = Images.AddImage(ProductImageSmallFile, folder);
                Product.ProductImageSmall = pathsmall;
                #endregion
            }


            Product.CreateDate = DateTime.Now;
            Product.UpdateDate = DateTime.Now;
            await context.Products.AddAsync(Product);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateProductAsync(Product Product,  IFormFile? ProductImageMainFile, IFormFile? ProductImageSmallFile, string folder)
    {
        try
        {
            if (ProductImageMainFile != null)
            {
                #region Save ProductImageMain
                string pathmain = Images.AddImage(ProductImageMainFile, folder);
                Product.ProductImageMain = pathmain;
                #endregion
            }
            if (ProductImageSmallFile != null)
            {
                #region Save ProductImageSmall  
                string pathsmall = Images.AddImage(ProductImageSmallFile, folder);
                Product.ProductImageSmall = pathsmall;
                #endregion
            }



            Product.UpdateDate = DateTime.Now;
            context.Products.Update(Product);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }
}
