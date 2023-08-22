using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.ReactOnBlog;
using ASP_Projekat.Application.UseCases.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReactOnBlogController : ControllerBase
    {

        private ICommandHandler _handler;
        private IApplicationUser _user;

        public ReactOnBlogController(ICommandHandler handler, IApplicationUser user)
        {
            _handler = handler;
            _user = user;
        }

        // POST api/<ReactOnCommentController>
        [HttpPost]
        public IActionResult Post([FromBody] ReactOnBlogDTO dto, [FromServices] IReactOnBlogCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created, new { message = "You Reacted On Blog Successfully" });
        }


        // DELETE api/<ReactOnCommentController>/5
        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id, int idReaction, int idUser, [FromServices] IDeleteReactionOnBlogCommand command)
        {
            var ints = new List<int>();
            ints.Add(id);
            ints.Add(idReaction);
            ints.Add(idUser);
            _handler.HandleCommand(command, ints);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "You Deleted Reaction On Blog Successfully" });
        }
    }
}
