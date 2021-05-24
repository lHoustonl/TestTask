using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;
using Test.Data;

namespace Test.DataAccess.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int id);
        void UpdateUser(User user);
        void SaveChanges();
    }
}
