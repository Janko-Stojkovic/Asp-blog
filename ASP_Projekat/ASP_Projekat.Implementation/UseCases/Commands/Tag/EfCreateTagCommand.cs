using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Tag;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Tag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Tag
{
    public class EfCreateTagCommand : ICreateTagCommand
    {
        private BlogDbContext _context;
        private CreateTagValidator _validator;
        private readonly IApplicationUser _user;

        public EfCreateTagCommand(BlogDbContext context, CreateTagValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public int Id => 1;

        public string Name => "Create New Tag";

        public string Description => "Create New Tag";

        public void Execute(CreateTagDTO request)
        {
            _validator.ValidateAndThrow(request);

            Domain.Entities.Tag tag = new Domain.Entities.Tag
            {
                TagText = request.Tag,
            };

            _context.Tags.Add(tag);

            _context.SaveChanges();
        }
    }
}
