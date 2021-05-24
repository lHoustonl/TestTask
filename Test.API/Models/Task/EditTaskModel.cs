using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.API.Models.Task
{
    public class EditTaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastChange { get; set; }

        public int? PerformerID { get; set; }
    }
}
