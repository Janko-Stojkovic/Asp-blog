using ASP_Projekat.API.Core;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JwtManager _jwtManager;

        public AuthController(JwtManager jwtManager)
        {
            _jwtManager = jwtManager;
        }


        // POST api/<TokenController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] AuthRequest request, [FromServices] BlogDbContext context)
        {
            try
            {

                string token = _jwtManager.MakeToken(request.Email, request.Password);

                return Ok(new { token });
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
 
    }
}
