using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Image;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Image;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Image
{
    public class EfDeleteImageCommand : IDeleteImageCommand
    {
        private BlogDbContext _context;
        private DeleteImageValidator _validator;
        private readonly IApplicationUser _user;
        public int Id => 8;
        public string Name => "Delete Image";

        public string Description => "Delete Image";

        public EfDeleteImageCommand(BlogDbContext context, DeleteImageValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public void Execute(int request)
        {
            var data = _context.Images.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;
            data.DeletedBy = _user.Username;

            _context.SaveChanges();
        }
    }
}
