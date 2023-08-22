using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Role;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Role
{
    public class EfDeleteRoleCommand : IDeleteRoleCommand
    {
        private BlogDbContext _context;
        private IApplicationUser _user;
        private DeleteRoleValidator _validator;

        public EfDeleteRoleCommand(BlogDbContext context, IApplicationUser user, DeleteRoleValidator validator)
        {
            _context = context;
            _user = user;
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Delete Role";

        public string Description => "Delete Role";

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);
            _validator.ValidateAndThrow(request);

            role.IsActive = false;
            role.DeletedAt = DateTime.UtcNow;
            role.DeletedBy = _user.Username;
            _context.SaveChanges();
        }
    }
}
