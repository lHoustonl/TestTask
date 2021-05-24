using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models.Page;

namespace Test.API.Models.Task
{
    public class IndexTaskSetterModel
    {
        public IEnumerable<TaskInfoModel> Tasks { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
