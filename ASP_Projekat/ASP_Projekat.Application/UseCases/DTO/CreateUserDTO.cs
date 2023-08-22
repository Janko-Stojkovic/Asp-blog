using Microsoft.AspNetCore.Http;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public IFormFile? ImageId { get; set; }
        public string? ImageFileName { get; set; }
    }
}
