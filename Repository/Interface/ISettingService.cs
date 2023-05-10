using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface ISettingService
{
    Task<bool> AddSettingAsync(Setting Setting, IFormFile SettingImageFile, string folder);
    Task<bool> UpdateSettingAsync(Setting Setting, IFormFile? SettingImageFile, string folder);
}
