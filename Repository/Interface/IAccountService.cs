using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface;

public interface IAccountService
{
    bool RegisterUser(User user);
    bool IsExistUser(User user);

    string GetRoleNameByUser(User user);
}
