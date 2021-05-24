using System;
using System.Collections.Generic;
using System.Text;
using Test.API.Services.UserTaskService;
using Test.Data.Models;
using Test.DataAccess.Database;
using Test.DataAccess.Repositories;

namespace Test.API.Services.UserTaskService
{
    public class DefaultUserTaskService : IUserTaskService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;

        public DefaultUserTaskService(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public bool SetTaskPerformer(int userId, int taskId)
        {
            var user = _userRepository.GetUserByID(userId);
            var task = _taskRepository.GetTaskByID(taskId);

            if(user != null && task != null)
            {
                task.PerformerID = user.UserID;
                _taskRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public bool UpdateTaskSetter(int userId, int taskId)
        {
            var user = _userRepository.GetUserByID(userId);
            var task = _taskRepository.GetTaskByID(taskId);

            if (user != null && task != null)
            {

                task.SetterID = user.UserID;
                _taskRepository.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
