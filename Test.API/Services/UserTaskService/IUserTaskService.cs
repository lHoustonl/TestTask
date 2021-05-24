using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;

namespace Test.API.Services.UserTaskService
{
    public interface IUserTaskService
    {
        bool SetTaskPerformer(int userId, int taskId);
        bool UpdateTaskSetter(int userId, int taskId);
    }
}
