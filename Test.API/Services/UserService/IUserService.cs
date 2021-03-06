using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Models;
using Test.Data;
using Test.API.Models.User;

namespace Test.API.Services.UserService
{
    public interface IUserService
    {
        IndexUserModel GetUsersPage(int page);
        User GetUser(int id);
        User UpdateUser(int id, EditUserModel editableUser);
    }
}
