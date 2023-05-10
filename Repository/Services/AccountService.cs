using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public class AccountService: IAccountService
{
    AppDbContext context;
    public AccountService(AppDbContext context)
    {
        this.context = context;
    }

    public bool RegisterUser(User user)
    {
        if (!string.IsNullOrEmpty(user.Mobile) && !string.IsNullOrEmpty(user.Password))
        {
            var _user = new User() 
            {
              Mobile= user.Mobile,
              Password= user.Password,
              RoleId=2,
              CreateDate=DateTime.Now,
              UpdateDate=DateTime.Now
            };
          
            context.Users.Add(_user);
            context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
       
    }

    public bool IsExistUser(User user)
    {
        var res = context.Users.Any(x => x.Mobile == user.Mobile && x.Password == user.Password);

        return res; 
    }

    public string GetRoleNameByUser(User user)
    {
        var _user = context.Users.Include(x=>x.Role).FirstOrDefault(x => x.Mobile == user.Mobile && x.Password == user.Password);
        
        return _user?.Role?.RoleName??"";

    }
}
