using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Models;

namespace Test.API.Models.Task
{
    public class TaskInfoModel
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastChange { get; set; }
        public TaskStatuses TaskStatus { get; set; } //Task status values: Not started, In progress, Accomplished, Canceled, Rejected

        public int? SetterID { get; set; }
        public int? PerformerID { get; set; }
    }
}
