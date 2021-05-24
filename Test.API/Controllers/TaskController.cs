using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.API.Models.Task;
using Test.API.Services.TaskService;
using Test.API.Services.UserTaskService;

namespace Test.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private ITaskService _taskService;
        private IUserTaskService _userTaskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService, IUserTaskService userTaskService)
        {
            _logger = logger;
            _taskService = taskService;
            _userTaskService = userTaskService;
        }

        [HttpGet("setter/{userId:int}/page/{pageNumber:int}")]
        public IActionResult GetSetterTasks(int userId, int pageNumber)
        {
            var tasks = _taskService.GetSetterTasks(userId, pageNumber);

            if (tasks == null)
                return BadRequest("Tasks not found");

            return Ok(tasks);
        }

        [HttpGet("performer/{userId:int}/page/{pageNumber:int}")]
        public IActionResult GetPerformerTasks(int userId, int pageNumber)
        {
            var tasks = _taskService.GetPerformerTasks(userId, pageNumber);

            if (tasks == null)
                return BadRequest("Tasks not found");

            return Ok(tasks);
        }

        [HttpGet("{taskId:int}")]
        public IActionResult GetTask(int taskId)
        {
            var task = _taskService.GetTask(taskId);

            if (task == null)
                return BadRequest("Task not found");

            var model = new TaskInfoModel()
            {
                TaskID = task.TaskID,
                Name = task.Name,
                Description = task.Description,
                DateOfCreation = task.DateOfCreation,
                DateOfLastChange = task.DateOfLastChange,
                TaskStatus = task.TaskStatus,
                SetterID = task.SetterID,
                PerformerID = task.PerformerID
            };

            return Ok(model);
        }

        [HttpPut("{taskId:int}/update")]
        public IActionResult UpdateTask(int taskId, [FromBody] EditTaskModel values)
        {
            var task = _taskService.UpdateTask(taskId, values);

            if (task == null)
                return BadRequest("User not found");

            var model = new TaskInfoModel()
            {
                TaskID = task.TaskID,
                Name = task.Name,
                Description = task.Description,
                DateOfCreation = task.DateOfCreation,
                DateOfLastChange = task.DateOfLastChange,
                TaskStatus = task.TaskStatus,
                SetterID = task.SetterID,
                PerformerID = task.PerformerID
            };

            return Ok(model);
        }

        [HttpPut("{taskId:int}/update/status/{taskStatus}")]
        public IActionResult UpdateTaskStatus(int taskId, int taskStatus)
        {
            var status = _taskService.UpdateTaskStatus(taskId, taskStatus);

            if (status)
                return Ok();

            return BadRequest("Task/Status not found");
        }

        [HttpPut("{userId:int}/set/setter/{taskId:int}")]
        public IActionResult SetSetter(int userId, int taskId)
        {
            var result = _userTaskService.UpdateTaskSetter(userId, taskId);

            if (result)
                return Ok();
            else
                return BadRequest("User/Task not found");
        }
    }
}
