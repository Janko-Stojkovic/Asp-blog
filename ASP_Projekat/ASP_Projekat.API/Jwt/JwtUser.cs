using ASP_Projekat.Application;

namespace ASP_Projekat.API.Core
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public IEnumerable<int> UseCaseIds { get; set; }
    }
    public class AnonimousUser : IApplicationUser
    {
        public int Id => 0;

        public string Email => "anonimous@test.com";

        public string Username => "Anonimous";

        public IEnumerable<int> UseCaseIds => new List<int> { 4 };
    }
}
