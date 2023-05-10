using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IServiceService
{
    Task<bool> AddServiceAsync(Service Service, IFormFile? ServiceImageFile, string folder);
    Task<bool> UpdateServiceAsync(Service Service, IFormFile? ServiceImageFile, string folder);
}
