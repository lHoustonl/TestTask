using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models.Page;

namespace Test.API.Models.User
{
    public class IndexUserModel
    {
        public IEnumerable<UserInfoModel> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
