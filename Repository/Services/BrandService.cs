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

public class BrandService : IBrandService
{
    private readonly AppDbContext context;
    public BrandService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddBrandAsync(Brand Brand, IFormFile? BrandImageFile, string folder)
    {
        try
        {
            if (BrandImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(BrandImageFile, folder);
                Brand.BrandImage = path;
                #endregion
            }


            Brand.CreateDate = DateTime.Now;
            Brand.UpdateDate = DateTime.Now;
            await context.Brands.AddAsync(Brand);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateBrandAsync(Brand Brand, IFormFile? BrandImageFile, string folder)
    {
        try
        {
            if (BrandImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(BrandImageFile, folder);
                Brand.BrandImage = path;
                #endregion
            }



            Brand.UpdateDate = DateTime.Now;
            context.Brands.Update(Brand);
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
