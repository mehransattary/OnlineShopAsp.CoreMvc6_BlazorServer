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

public class AdvertiseService : IAdvertiseService
{
    private readonly AppDbContext context;
    public AdvertiseService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddAdvertiseAsync(Advertise Advertise, IFormFile AdvertiseImageFile, string folder)
    {
        try
        {

            #region Save Image
            string path = Images.AddImage(AdvertiseImageFile, folder);
            Advertise.AdvertiseImage = path;
            #endregion

            Advertise.CreateDate = DateTime.Now;
            Advertise.UpdateDate = DateTime.Now;
            await context.Advertises.AddAsync(Advertise);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateAdvertiseAsync(Advertise Advertise, IFormFile? AdvertiseImageFile, string folder)
    {
        try
        {
            if (AdvertiseImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(AdvertiseImageFile, folder);
                Advertise.AdvertiseImage = path;
                #endregion
            }



            Advertise.UpdateDate = DateTime.Now;
            context.Advertises.Update(Advertise);
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
