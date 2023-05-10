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

public class ServiceService: IServiceService
{
    private readonly AppDbContext context;
    public ServiceService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddServiceAsync(Service Service, IFormFile? ServiceImageFile, string folder)
    {
        try
        {
            if (ServiceImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(ServiceImageFile, folder);
                Service.ServiceImage = path;
                #endregion
            }


            Service.CreateDate = DateTime.Now;
            Service.UpdateDate = DateTime.Now;
            await context.Services.AddAsync(Service);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateServiceAsync(Service Service, IFormFile? ServiceImageFile, string folder)
    {
        try
        {
            if (ServiceImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(ServiceImageFile, folder);
                Service.ServiceImage = path;
                #endregion
            }



            Service.UpdateDate = DateTime.Now;
            context.Services.Update(Service);
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
