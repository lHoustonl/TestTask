using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Data;

namespace Test.API.Models.User
{
    public class UserInfoModel
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastChange { get; set; }
        public UserStatuses UserStatus { get; set; } //Values: Active, Disabled, Locked
    }
}
