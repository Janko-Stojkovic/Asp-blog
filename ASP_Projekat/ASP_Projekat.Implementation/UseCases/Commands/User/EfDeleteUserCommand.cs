using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.User;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.User
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private BlogDbContext _context;
        private DeleteUserValidator _validator;
        private readonly IApplicationUser _user;

        public EfDeleteUserCommand(BlogDbContext context, DeleteUserValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public int Id => 16;

        public string Name => "Delete User";

        public string Description => "Delete User";

        public void Execute(int request)
        {

            var data = _context.Users.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;
            data.DeletedBy = _user.Username;

            _context.SaveChanges();


        }
    }
}
