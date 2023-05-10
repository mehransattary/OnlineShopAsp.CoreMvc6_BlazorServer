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

namespace Repository.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly AppDbContext context;
        public CategoryService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddCategoryAsync(Category Category, IFormFile? CategoryImageFile, string folder)
        {
            try
            {
                if(CategoryImageFile!=null)
                {
                    #region Save Image
                    string path = Images.AddImage(CategoryImageFile, folder);
                    Category.CategoryImage = path;
                    #endregion
                }


                Category.CreateDate = DateTime.Now;
                Category.UpdateDate = DateTime.Now;
                await context.Categories.AddAsync(Category);
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public async Task<bool> UpdateCategoryAsync(Category Category, IFormFile? CategoryImageFile, string folder)
        {
            try
            {
                if (CategoryImageFile != null)
                {
                    #region Save Image
                    string path = Images.AddImage(CategoryImageFile, folder);
                    Category.CategoryImage = path;
                    #endregion
                }



                Category.UpdateDate = DateTime.Now;
                context.Categories.Update(Category);
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
}
