using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.API.Models.User;
using Test.API.Services.UserService;
using Test.API.Services.UserTaskService;

namespace Test.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;
        private IUserTaskService _userTaskService;

        public UserController(ILogger<UserController> logger, IUserService userService, IUserTaskService userTaskService)
        {
            _logger = logger;
            _userService = userService;
            _userTaskService = userTaskService;
        }

        [HttpGet("page/{pageNumber:int}")]
        public IActionResult GetUsers(int pageNumber)
        {
            var page = _userService.GetUsersPage(pageNumber);

            if (page == null)
                return BadRequest("Users not found");

            return Ok(page);
        }

        [HttpGet("{userId:int}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);

            if(user == null)
                return BadRequest("User not found");

            var model = new UserInfoModel()
            {
                UserID = user.UserID,
                LastName = user.LastName,
                FirstName = user.FirstName,
                DateOfCreation = user.DateOfCreation,
                DateOfLastChange = user.DateOfLastChange,
                UserStatus = user.UserStatus
            };

            return Ok(model);
        }

        [HttpPut("{userId:int}/update")]
        public IActionResult UpdateUser(int userId, [FromBody]EditUserModel values)
        {
            var user = _userService.UpdateUser(userId, values);

            if (user == null)
                return BadRequest("User not found");

            var model = new UserInfoModel()
            {
                UserID = user.UserID,
                LastName = user.LastName,
                FirstName = user.FirstName,
                DateOfCreation = user.DateOfCreation,
                DateOfLastChange = user.DateOfLastChange,
                UserStatus = user.UserStatus
            };

            return Ok(model);
        }

        [HttpPut("{userId:int}/set/task/{taskId:int}")]
        public IActionResult SetPerformer(int userId, int taskId)
        {
            var result = _userTaskService.SetTaskPerformer(userId, taskId);

            if (result)
                return Ok();
            else
                return BadRequest("User/Task not found");
        }
    }
}
