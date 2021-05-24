using System;
using System.Collections.Generic;
using System.Linq;
using Test.API.Models.Page;
using Test.API.Models.Task;
using Test.Data.Models;
using Test.DataAccess.Repositories;

namespace Test.API.Services.TaskService
{
    public class DefaultTaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public DefaultTaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IndexTaskPerformerModel GetPerformerTasks(int userId, int page)
        {
            int pageSize = 4;

            IEnumerable<Task> tasks = _taskRepository.GetPerformerTasks(userId).Skip((page - 1) * pageSize).Take(pageSize);

            var tasksInfo = tasks.Select(t => new TaskInfoModel()
            {
                TaskID = t.TaskID,
                Name = t.Name,
                Description = t.Description,
                DateOfCreation = t.DateOfCreation,
                DateOfLastChange = t.DateOfLastChange,
                TaskStatus = t.TaskStatus,
                SetterID = t.SetterID,
                PerformerID = t.PerformerID
            }).ToArray();

            PageViewModel pageViewModel = new PageViewModel(_taskRepository.GetPerformerTasks(userId).Count(), page, pageSize);
            IndexTaskPerformerModel taskPerformerModel = new IndexTaskPerformerModel
            {
                PageViewModel = pageViewModel,
                Tasks = tasksInfo
            };

            return taskPerformerModel;
        }

        public IndexTaskSetterModel GetSetterTasks(int userId, int page)
        {
            int pageSize = 4;

            IEnumerable<Task> tasks = _taskRepository.GetSetterTasks(userId).Skip((page - 1) * pageSize).Take(pageSize);

            var tasksInfo = tasks.Select(t => new TaskInfoModel()
            {
                TaskID = t.TaskID,
                Name = t.Name,
                Description = t.Description,
                DateOfCreation = t.DateOfCreation,
                DateOfLastChange = t.DateOfLastChange,
                TaskStatus = t.TaskStatus,
                SetterID = t.SetterID,
                PerformerID = t.PerformerID
            }).ToArray();

            PageViewModel pageViewModel = new PageViewModel(_taskRepository.GetSetterTasks(userId).Count(), page, pageSize);
            IndexTaskSetterModel indexTaskSetterModel = new IndexTaskSetterModel
            {
                PageViewModel = pageViewModel,
                Tasks = tasksInfo
            };

            return indexTaskSetterModel;
        }

        public Task GetTask(int id)
            => _taskRepository.GetTaskByID(id);

        public Task UpdateTask(int id, EditTaskModel values)
        {
            var task = GetTask(id);

            if (task != null)
            {
                task.Name = values.Name ?? task.Name;

                task.Description = values.Description ?? task.Description;

                if (values.DateOfCreation != null)
                {
                    task.DateOfCreation = values.DateOfCreation;
                }

                if (values.DateOfLastChange != null)
                {
                    task.DateOfLastChange = values.DateOfLastChange;
                }

                if (values.PerformerID != null)
                {
                    task.PerformerID = values.PerformerID;
                }

                _taskRepository.SaveChanges();
            }

            return task;
        }

        public bool UpdateTaskStatus(int id, int taskStatus)
        {
            var task = GetTask(id);

            if (task != null)
            {
                int minStatus = Enum.GetValues(typeof(TaskStatuses)).Cast<int>().Min();
                int maxStatus = Enum.GetValues(typeof(TaskStatuses)).Cast<int>().Max();

                if (taskStatus >= minStatus && taskStatus <= maxStatus)
                {
                    task.TaskStatus = (TaskStatuses)taskStatus;

                    _taskRepository.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
