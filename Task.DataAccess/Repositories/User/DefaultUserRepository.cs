using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;
using Test.DataAccess.Database;

namespace Test.DataAccess.Repositories
{
    public class DefaultUserRepository : IUserRepository
    {
        private TestDatabase db;

        public DefaultUserRepository(TestDatabase context) => db = context;

        public User GetUserByID(int id)
            => db.Users.FirstOrDefault(u => u.UserID == id);

        public IEnumerable<User> GetUsers()
            => db.Users.ToArray();

        public void SaveChanges()
            => db.SaveChanges();
        public async void SaveChangesAsync()
            => await db.SaveChangesAsync();

        public void UpdateUser(User user)
            => db.Update<User>(user);
    }
}
