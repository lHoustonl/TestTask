using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Data.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastChange { get; set; }
        public UserStatuses UserStatus { get; set; } //Values: Active, Disabled, Locked
    }

    public enum UserStatuses
    {
        Active,
        Disabled,
        Locked
    }
}
