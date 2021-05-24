using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;
using Test.Data;

namespace Test.DataAccess.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetSetterTasks(int userId);
        IEnumerable<Task> GetPerformerTasks(int userId);
        public Task GetTaskByID(int id);
        void UpdateTask(Task task);
        public void SaveChanges();
    }
}
