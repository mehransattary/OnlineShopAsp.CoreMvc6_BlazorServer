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

namespace Repository.Servicesl;

public class BlogService: IBlogService
{
    private readonly AppDbContext context;
    public BlogService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddBlogAsync(Blog Blog, IFormFile? BlogImageMainFile, IFormFile? BlogImageSmallFile, string folder)
    {
        try
        {
            if (BlogImageMainFile != null)
            {
                #region Save BlogImageMain
                string path = Images.AddImage(BlogImageMainFile, folder);
                Blog.BlogImageMain = path;
                #endregion
            }
            if (BlogImageSmallFile != null)
            {
                #region Save BlogImageSmall
                string path = Images.AddImage(BlogImageSmallFile, folder);
                Blog.BlogImageSmall = path;
                #endregion
            }

            Blog.CreateDate = DateTime.Now;
            Blog.UpdateDate = DateTime.Now;
            await context.Blogs.AddAsync(Blog);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateBlogAsync(Blog Blog, IFormFile? BlogImageMainFile, IFormFile? BlogImageSmallFile, string folder)
    {
        try
        {
            if (BlogImageMainFile != null)
            {
                #region Save BlogImageMain
                string path = Images.AddImage(BlogImageMainFile, folder);
                Blog.BlogImageMain = path;
                #endregion
            }
            if (BlogImageSmallFile != null)
            {
                #region Save BlogImageSmall
                string path = Images.AddImage(BlogImageSmallFile, folder);
                Blog.BlogImageSmall = path;
                #endregion
            }



            Blog.UpdateDate = DateTime.Now;
            context.Blogs.Update(Blog);
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
