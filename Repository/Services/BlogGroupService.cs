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

public class BlogGroupService: IBlogGroupService
{
    private readonly AppDbContext context;
    public BlogGroupService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddBlogGroupAsync(BlogGroup BlogGroup, IFormFile? BlogGroupImageFile, string folder)
    {
        try
        {
            if (BlogGroupImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(BlogGroupImageFile, folder);
                BlogGroup.BlogGroupImage = path;
                #endregion
            }


            BlogGroup.CreateDate = DateTime.Now;
            BlogGroup.UpdateDate = DateTime.Now;
            await context.BlogGroups.AddAsync(BlogGroup);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateBlogGroupAsync(BlogGroup BlogGroup, IFormFile? BlogGroupImageFile, string folder)
    {
        try
        {
            if (BlogGroupImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(BlogGroupImageFile, folder);
                BlogGroup.BlogGroupImage = path;
                #endregion
            }



            BlogGroup.UpdateDate = DateTime.Now;
            context.BlogGroups.Update(BlogGroup);
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
