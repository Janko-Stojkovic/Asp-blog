using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.Role;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Role;
using ASP_Projekat.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private BlogDbContext _context;
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public RoleController(BlogDbContext context, IApplicationUser user, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Roles.Where(x=>x.IsActive == true);
            if (data == null)
            {
                return NotFound(new { message = "There Isn`t Any Role In Our Database" });
            }
            return Ok(data);
        }
        /// <summary>
        /// Get Role With Provided ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRoleQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        /// <summary>
        /// Add New Role
        /// </summary>
        /// <param name="value"></param>
        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoleDTO dto, [FromServices] ICreateRoleCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created, new { message = "Role Created Successfully." });
        }


        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "Role Deleted Successfully." });
        }
    }
}
