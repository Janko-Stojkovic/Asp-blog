using ASP_Projekat.Domain;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Application.UseCases.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ASP_Projekat.API.Extensions.StringExtensions;
using ASP_Projekat.Domain.Entities;
using System.Xml;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application;
using ASP_Projekat.Application.Logging;
using ASP_Projekat.Implementation.Validators;
using ASP_Projekat.API.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.Blog;
using ASP_Projekat.Application.Exceptions;
using ASP_Projekat.Application.UseCases.Queries.Blog;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly BlogDbContext _context;
        private readonly IExceptionLogger _logger;
        private IQueryHandler _queryHandler;


        public BlogController(IExceptionLogger logger, BlogDbContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _context = context;
            _logger = logger;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Select All Blogs Or Search It With Keyword
        /// </summary>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>

        // GET: api/<BlogController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] SearchBlog search, [FromServices] ISearchBlogsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }



        /// <summary>
        /// Search Blog With Specific ID
        /// </summary>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetBlogQuery query)
        {
           return Ok(_queryHandler.HandleQuery(query, id)); 
        }

        /// <summary>
        /// Create New Blog
        /// </summary>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBlogDTO dto, 
                                  [FromServices] ICreateBlogCommand command)
        {
           _commandHandler.HandleCommand(command, dto);
           return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Update Blog With Specific ID
        /// </summary>
        ///<response code="204">No Content</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBlogDTO dto, [FromServices] IUpdateBlogCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        /// <summary>
        /// Delete Requested Blog
        /// </summary>
        ///<response code="204">No Content</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBlogCommand command)
        {
     
                _commandHandler.HandleCommand(command, id);
                return StatusCode(StatusCodes.Status204NoContent);
          
        }

    }
}
