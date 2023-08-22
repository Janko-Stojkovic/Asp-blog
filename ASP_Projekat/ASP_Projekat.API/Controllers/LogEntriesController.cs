using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.LogEntries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogEntriesController : ControllerBase
    {
        private IQueryHandler _handler;

        public LogEntriesController(IQueryHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<LogEntriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchLogEntries dto, [FromServices] IGetLogEntriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        
    }
}
