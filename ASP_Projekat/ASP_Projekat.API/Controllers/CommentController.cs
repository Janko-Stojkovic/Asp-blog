using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.Comment;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public CommentController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<CommentController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] SearchCommentDTO dto, [FromServices] ISearchCommentQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, dto));
        }


        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDTO dto, [FromServices] ICreateCommentCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created, new { message = "Comment Is Created Successfully" });
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDTO dto, [FromServices] IUpdateCommentCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command,dto);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "Comment Is Updated Successfully" });
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent, new {message = "Comment Is Deleted Successfully"});
        }
    }
}
