using System;
using InternalDslTaskManagement.Builder.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternalDslTaskManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagementController : ControllerBase
    {
        private readonly IRootBuilder _rootBuilder;

        public TaskManagementController(IRootBuilder rootBuilder)
        {
            _rootBuilder = rootBuilder;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            _rootBuilder
                .Task("Mega wow!").Assign("Daniel").Deadline(DateTime.Now).Status("To-do")
                .Label("NewLabel")
                .Comment("Wowowow").By("Dani boi").PostedAt(DateTime.Now)
                .Comment("Wowowow2").By("Dani boi").PostedAt(DateTime.Now)
                .Label("NewLabel2").Label("NewLabel3")
                .Task("New mega wow!");
            return StatusCode(StatusCodes.Status200OK, "wow, much success");
        }
    }
}