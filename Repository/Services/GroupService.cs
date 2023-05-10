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

public class GroupService : IGroupService
{
    private readonly AppDbContext context;
    public GroupService(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddGroupAsync(Group Group, IFormFile? GroupImageFile, string folder)
    {
        try
        {
            if (GroupImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(GroupImageFile, folder);
                Group.GroupImage = path;
                #endregion
            }


            Group.CreateDate = DateTime.Now;
            Group.UpdateDate = DateTime.Now;
            await context.Groups.AddAsync(Group);
            await context.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    public async Task<bool> UpdateGroupAsync(Group Group, IFormFile? GroupImageFile, string folder)
    {
        try
        {
            if (GroupImageFile != null)
            {
                #region Save Image
                string path = Images.AddImage(GroupImageFile, folder);
                Group.GroupImage = path;
                #endregion
            }



            Group.UpdateDate = DateTime.Now;
            context.Groups.Update(Group);
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
