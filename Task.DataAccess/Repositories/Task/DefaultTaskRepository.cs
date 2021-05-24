using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;

namespace Test.DataAccess.Repositories
{
    public class DefaultTaskRepository : ITaskRepository
    {
        public Task GetTaskByID(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
