using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface ISliderService
{
     Task<bool> AddSliderAsync(Slider Slider, IFormFile SliderImageFile, string folder);
    Task<bool> UpdateSliderAsync(Slider Slider, IFormFile? SliderImageFile, string folder);

}
