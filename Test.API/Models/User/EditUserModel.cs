using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.API.Models.User
{
    public class EditUserModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastChange { get; set; }
    }
}
