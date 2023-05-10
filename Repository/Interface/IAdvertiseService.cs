using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IAdvertiseService
{
    Task<bool> AddAdvertiseAsync(Advertise Advertise, IFormFile AdvertiseImageFile, string folder);
    Task<bool> UpdateAdvertiseAsync(Advertise Advertise, IFormFile? AdvertiseImageFile, string folder);
}
