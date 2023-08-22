using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.Reaction;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Reaction;
using ASP_Projekat.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReactionController : ControllerBase
    {
        private BlogDbContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public ReactionController(BlogDbContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)     
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Search For All Reactions
        /// </summary>
        /// <returns></returns>
        // GET: api/<ReactionController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Reactions;
            if (data == null)
            {
                return NotFound(new { message = "There isnt any reaction value in our database" });
            }
            return Ok(data);
        }

        // GET api/<ReactionController>/5
        ///<summary>
        /// Search For Reaction With Provided ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetReactionQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        /// <summary>
        /// Adding New Reaction
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        // POST api/<ReactionController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReactionDTO dto, [FromServices] ICreateReactionCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "Reaction Created Successfully." });
        }

        /// <summary>
        /// Deleting Reaction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        // DELETE api/<ReactionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReactionCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "Reaction Deleted Successfully." });
        }
    }
}
