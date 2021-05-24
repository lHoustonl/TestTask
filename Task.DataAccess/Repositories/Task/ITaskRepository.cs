using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;
using Test.Data;

namespace Test.DataAccess.Repositories
{
    public interface ITaskRepository
    {
        public Task GetTaskByID(int id);
        public void SaveChanges();
    }
}
