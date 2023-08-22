using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Tag;
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
    public class EfDeleteTagCommand : IDeleteTagCommand
    {
        private BlogDbContext _context;
        private DeleteTagValidator _validator;
        private readonly IApplicationUser _user;

        public EfDeleteTagCommand(BlogDbContext context, DeleteTagValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public int Id => 2;

        public string Name => "Delete Tag";

        public string Description => "Delete Tag";

        public void Execute(int request)
        {
            var data = _context.Tags.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;
            data.DeletedBy = _user.Username;

            _context.SaveChanges();
        }
    }
}
