using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.Tag;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Tag;
using ASP_Projekat.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        private BlogDbContext _context;

        public TagController(BlogDbContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;
        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Tags.Where(x => x.IsActive == true);
            if(data == null)
            {
                return NotFound(new { message = "There isnt any tag value in our database" });
            }
            return Ok(data);
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetTagQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<TagController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateTagDTO dto, [FromServices] ICreateTagCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created, new { message = "Tag Created Successfully." });
        }


        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "Tag Deleted Successfully." });
        }
    }
}
