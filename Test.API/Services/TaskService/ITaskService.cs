using System;
using System.Collections.Generic;
using System.Linq;
using Test.API.Models.Task;
using Test.Data.Models;

namespace Test.API.Services.TaskService
{
    public interface ITaskService
    {
        IndexTaskSetterModel GetSetterTasks(int userId, int page);
        IndexTaskPerformerModel GetPerformerTasks(int userId, int page);
        Task GetTask(int id);
        Task UpdateTask(int id, EditTaskModel editableTask);
        bool UpdateTaskStatus(int id, int taskStatus);
    }
}
