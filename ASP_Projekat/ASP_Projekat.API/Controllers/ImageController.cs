using ASP_Projekat.API.DTO;
using ASP_Projekat.Domain;
using ASP_Projekat.Application.UseCases.DTO;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Authorization;
using ASP_Projekat.DataAccess;
using Microsoft.EntityFrameworkCore;
using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.Logging;
using ASP_Projekat.Application.UseCases.Queries.Image;
using ASP_Projekat.Application.UseCases.Commands.Image;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private BlogDbContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;


        public ImageController(BlogDbContext context, IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<ImageController>
        [HttpGet]
        public IActionResult Get()
        {
                var data = _context.Images.Where(x=>x.IsActive == true);
                if (data == null)
                {
                    return NotFound(new { message = "There Isn`t Any Image In Our Database." });
                }
                return Ok(data);
        }


        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetImageQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ImageController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateImageDTO dto, [FromServices] ICreateImageCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created, new { message = "Image Added Successfully" });
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteImageCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent, new { message = "Image Successfully Deleted." });
        }
    }

    
}
