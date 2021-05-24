using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DateOfCreation { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DateOfLastChange { get; set; }
        public TaskStatuses TaskStatus { get; set; } //Task status values: Not started, In progress, Accomplished, Canceled, Rejected

        [ForeignKey("User")]
        public int? SetterID { get; set; }
        [ForeignKey("User")]
        public int? PerformerID { get; set; }

        public virtual User SetterUser { get; set; }
        public virtual User PerformerUser { get; set; }
    }

    public enum TaskStatuses
    {
        NotStarted,
        InProgress,
        Accomplished,
        Canceled,
        Rejected
    }
}
