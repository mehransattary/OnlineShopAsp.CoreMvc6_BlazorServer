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

public class SliderService : ISliderService
{
    private readonly AppDbContext context;
    public SliderService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddSliderAsync(Slider Slider, IFormFile SliderImageFile,string folder)
    {
        try
        {

            #region Save Image
            string path=  Images.AddImage(SliderImageFile, folder);
            Slider.SliderImage = path;
            #endregion

            Slider.CreateDate = DateTime.Now;
            Slider.UpdateDate = DateTime.Now;
            await context.Sliders.AddAsync(Slider);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateSliderAsync(Slider Slider, IFormFile? SliderImageFile, string folder)
    {
        try
        {
            if(SliderImageFile!=null)
            {
                #region Save Image
                string path = Images.AddImage(SliderImageFile, folder);
                Slider.SliderImage = path;
                #endregion
            }



            Slider.UpdateDate = DateTime.Now;
             context.Sliders.Update(Slider);
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
