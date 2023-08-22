using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Role;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.Role
{
    public class EfGetRoleQuery : IGetRoleQuery
    {
        private BlogDbContext _context;
        private GetRoleValidator _validator;
        private readonly IApplicationUser _user;
        public EfGetRoleQuery(BlogDbContext context, GetRoleValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 4;

        public string Name => "Get Role With ID";

        public string Description => "Get Role With ID";

        public RoleDTO Execute(int search)
        {

            Domain.Entities.Role role = _context.Roles.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);


            var roles = new RoleDTO
            {
                Id = role.Id,
                Name = role.RoleName
            };
            return (roles);

        }
    }
}
