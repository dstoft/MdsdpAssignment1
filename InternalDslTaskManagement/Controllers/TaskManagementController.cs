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
        private MdsdHomework MdsdHomework;

        public TaskManagementController(MdsdHomework mdsdHomework)
        {
            MdsdHomework = mdsdHomework;
        }

        [HttpPost]
        public ActionResult<string> Build()
        {
            MdsdHomework.Build();
            return StatusCode(StatusCodes.Status201Created, "Model successfully built!");
        }

        [HttpGet("tasks")]
        public ActionResult<ICollection<Task>> ListTasks()
        {
            return StatusCode(StatusCodes.Status200OK, MdsdHomework.GetTasks());
        }

        [HttpGet("labels")]
        public ActionResult<ICollection<Label>> ListLabels()
        {
            return StatusCode(StatusCodes.Status200OK, MdsdHomework.GetLabels());
        }
    }
}