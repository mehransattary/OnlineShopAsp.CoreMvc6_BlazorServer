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

public class SettingService: ISettingService
{
    private readonly AppDbContext context;
    public SettingService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddSettingAsync(Setting Setting, IFormFile SettingImageFile, string folder)
    {
        try
        {

            #region Save Image
            string path = Images.AddImage(SettingImageFile, folder);
            Setting.SettingLogo = path;
            #endregion

            Setting.CreateDate = DateTime.Now;
            Setting.UpdateDate = DateTime.Now;
            await context.Settings.AddAsync(Setting);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateSettingAsync(Setting Setting, IFormFile? SettingImageFile, string folder)
    {
        try
        {
            if (SettingImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(SettingImageFile, folder);
                Setting.SettingLogo = path;
                #endregion
            }



            Setting.UpdateDate = DateTime.Now;
            context.Settings.Update(Setting);
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
