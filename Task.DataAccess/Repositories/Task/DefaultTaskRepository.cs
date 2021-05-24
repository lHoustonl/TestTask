using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;
using Test.Data;
using Test.DataAccess.Database;

namespace Test.DataAccess.Repositories
{
    public class DefaultTaskRepository : ITaskRepository
    {
        private TestDatabase db;

        public DefaultTaskRepository(TestDatabase context) => db = context;
        public IEnumerable<Task> GetPerformerTasks(int userId)
            => db.Tasks.Where(t => t.PerformerID == userId).ToArray();

        public IEnumerable<Task> GetSetterTasks(int userId)
            => db.Tasks.Where(t => t.SetterID == userId).ToArray();

        public Task GetTaskByID(int id)
            => db.Tasks.FirstOrDefault(t => t.TaskID == id);

        public void SaveChanges()
            => db.SaveChanges();
        public async void SaveChangesAsync()
            => await db.SaveChangesAsync();

        public void UpdateTask(Task task)
            => db.Update<Task>(task);
    }
}
