using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Role;
using ASP_Projekat.Application.UseCases.DTO;
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
    public class EfCreateRoleCommand : ICreateRoleCommand
    {
        private BlogDbContext _context;
        private CreateRoleValidator _validator;
        private readonly IApplicationUser _user;

        public EfCreateRoleCommand(BlogDbContext context, CreateRoleValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 6;

        public string Name => "Create Role";

        public string Description => "Create Role";

        public void Execute(CreateRoleDTO request)
        {
            _validator.ValidateAndThrow(request);


            Domain.Entities.Role roles = new Domain.Entities.Role
            {
                RoleName = request.role,
            };


            _context.Roles.Add(roles);

            _context.SaveChanges();
        }
    }
}
