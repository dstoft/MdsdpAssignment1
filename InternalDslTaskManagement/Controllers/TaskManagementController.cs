using System.Collections.Generic;
using InternalDslTaskManagement.Dsl;
using InternalDslTaskManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternalDslTaskManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagementController : ControllerBase
    {
        private readonly HousePeace _housePeace;
        private readonly MdsdHomework _mdsdHomework;

        public TaskManagementController(MdsdHomework mdsdHomework, HousePeace housePeace)
        {
            _mdsdHomework = mdsdHomework;
            _housePeace = housePeace;
        }

        [HttpPost("{type}")]
        public ActionResult<string> Build(string type)
        {
            switch (type.ToLower())
            {
                case "mdsd":
                    _mdsdHomework.Build();
                    break;
                case "house":
                    _housePeace.Build();
                    break;
                default:
                    return StatusCode(StatusCodes.Status400BadRequest,
                        "Invalid task management type, only \"mdsd\" or \"house\" is allowed!");
            }

            return StatusCode(StatusCodes.Status201Created, "Model successfully built!");
        }

        [HttpGet("task")]
        public ActionResult<ICollection<Task>> ListTasks()
        {
            return StatusCode(StatusCodes.Status200OK, _mdsdHomework.ListTasks());
        }

        [HttpGet("task/{name}")]
        public ActionResult<ICollection<Task>> GetTask(string name)
        {
            return StatusCode(StatusCodes.Status200OK, _mdsdHomework.GetTask(name));
        }

        [HttpGet("label")]
        public ActionResult<ICollection<Label>> ListLabels()
        {
            return StatusCode(StatusCodes.Status200OK, _mdsdHomework.ListLabels());
        }

        [HttpGet("label/{name}")]
        public ActionResult<ICollection<Label>> GetLabel(string name)
        {
            return StatusCode(StatusCodes.Status200OK, _mdsdHomework.GetLabel(name));
        }
    }
}