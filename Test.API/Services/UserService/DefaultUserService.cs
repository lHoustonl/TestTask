using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models.User;
using Test.Data.Models;
using Test.DataAccess.Repositories;

namespace Test.API.Services.UserService
{
    public class DefaultUserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public DefaultUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int id)
            => _userRepository.GetUserByID(id);

        public User UpdateUser(int id, EditUserModel values)
        {
            var user = GetUser(id);

            if(user != null)
            {
                user.LastName = values.LastName ?? user.LastName;

                user.FirstName = values.FirstName ?? user.FirstName;

                if(values.DateOfCreation != null)
                {
                    user.DateOfCreation = values.DateOfCreation;
                }

                if (values.DateOfLastChange != null)
                {
                    user.DateOfLastChange = values.DateOfLastChange;
                }

                _userRepository.SaveChanges();
            }

            return user;
        }
    }
}
