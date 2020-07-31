using CustomMvcWebApi.Data;
using CustomMvcWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMvcWebApi.Controllers
{
    /// <summary>
    /// Returns all of commands
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]     //api/commands
    public class CommandsController : ControllerBase
    {
        ICommanderRepo _repo;

        public CommandsController(ICommanderRepo repo)
        {
            this._repo = repo;
        }

        private readonly MockCommandRepo _mockCommandRepo = new MockCommandRepo();
        /// <summary>
        /// Returns all commands of apllication
        /// </summary>
        /// <returns></returns>
        [HttpGet]   //GET api/commands        
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            var commands = _mockCommandRepo.GetCommands();
            return Ok(commands);
        }

        /// <summary>
        /// Returns some command by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]   //GET api/commands/{id}
        public ActionResult<Command> GetCommandById(int id)
        {
            return Ok(_mockCommandRepo.GetCommandById(id));
        }

        /// <summary>
        /// Adds some command to the list of commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult AddCommand([FromBody] Command command)
        {
            _mockCommandRepo.AddCommand(command);
            return Ok();
        }
    }
}
