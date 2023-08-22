using ASP_Projekat.Application.UseCases.Commands.Image;
using ASP_Projekat.Application.UseCases.DTO;
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
    public class EfCreateImageCommand : ICreateImageCommand
    {
        private BlogDbContext _context;
        private CreateImageValidator _validator;

        public EfCreateImageCommand(BlogDbContext context, CreateImageValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 9;

        public string Name => "Kreiranje slike";

        public string Description => "Kreiranje slike";

        public void Execute(CreateImageDTO request)
        {
            _validator.ValidateAndThrow(request);



            Domain.Entities.Image image = new Domain.Entities.Image
            {
                ImageSize = request.ImageSize,
                ImageUrl = request.ImageUrl
            };


            _context.Images.Add(image);

            _context.SaveChanges();
        }
    }
}
