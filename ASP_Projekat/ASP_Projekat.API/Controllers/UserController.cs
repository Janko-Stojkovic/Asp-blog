using ASP_Projekat.API.Extensions;
using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.User;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.User;
using ASP_Projekat.Implementation.UseCases.Queries.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".png", ".jpeg" };
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public UserController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        /// <summary>
        /// Search User With Keyword
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUser dto, [FromServices] ISearchUsersQuery query)
        {

            return Ok(_queryHandler.HandleQuery(query, dto));
        }

        /// <summary>
        /// Search User With ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,id));
        }


        /// <summary>
        /// Registration of new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/users
        ///     {
        ///        "email": "string",
        ///         "password": "string",
        ///         "name": "string",
        ///         "surname": "string",
        ///         "userName": "string",
        ///         "imageId": 0
        ///     }
        ///
        /// </remarks>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromForm] CreateUserDTO dto, [FromServices] ICreateUserCommand command)
        {
            if (dto.ImageId != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.ImageId.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file of uploading image.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "Images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.ImageId.CopyTo(stream);
                dto.ImageFileName = fileName;
            }
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        /// <summary>
        /// Update User
        /// </summary>
        ///<response code="204">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDTO dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        ///<response code="204">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not Found</response>
        ///<response code="401">Not Authorized</response>
        ///<response code="422">Validation error</response>
        /// <param name="id"></param>
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command) 
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
