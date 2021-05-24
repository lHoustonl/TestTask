using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models.Page;
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

        public IndexUserModel GetUsersPage(int page)
        {
            int pageSize = 4;

            IEnumerable<User> users = _userRepository.GetUsers().Skip((page - 1) * pageSize).Take(pageSize);

            var usersInfo = users.Select(u => new UserInfoModel()
            {
                UserID = u.UserID,
                LastName = u.LastName,
                FirstName = u.FirstName,
                DateOfCreation = u.DateOfCreation,
                DateOfLastChange = u.DateOfLastChange,
                UserStatus = u.UserStatus
            }).ToArray();

            PageViewModel pageViewModel = new PageViewModel(_userRepository.GetUsers().Count(), page, pageSize);
            IndexUserModel indexUserModel = new IndexUserModel
            {
                PageViewModel = pageViewModel,
                Users = usersInfo
            };

            return indexUserModel;
        }

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
