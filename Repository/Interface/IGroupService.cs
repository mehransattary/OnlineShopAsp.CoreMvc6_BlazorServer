using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IGroupService
{
    Task<bool> AddGroupAsync(Group Group, IFormFile? GroupImageFile, string folder);
    Task<bool> UpdateGroupAsync(Group Group, IFormFile? GroupImageFile, string folder);
}
