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

public class BlogCategoryService: IBlogCategoryService
{
    private readonly AppDbContext context;
    public BlogCategoryService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddBlogCategoryAsync(BlogCategory BlogCategory, IFormFile? BlogCategoryImageFile, string folder)
    {
        try
        {
            if (BlogCategoryImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(BlogCategoryImageFile, folder);
                BlogCategory.BlogCategoryImage = path;
                #endregion
            }


            BlogCategory.CreateDate = DateTime.Now;
            BlogCategory.UpdateDate = DateTime.Now;
            await context.BlogCategories.AddAsync(BlogCategory);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateBlogCategoryAsync(BlogCategory BlogCategory, IFormFile? BlogCategoryImageFile, string folder)
    {
        try
        {
            if (BlogCategoryImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(BlogCategoryImageFile, folder);
                BlogCategory.BlogCategoryImage = path;
                #endregion
            }



            BlogCategory.UpdateDate = DateTime.Now;
            context.BlogCategories.Update(BlogCategory);
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
