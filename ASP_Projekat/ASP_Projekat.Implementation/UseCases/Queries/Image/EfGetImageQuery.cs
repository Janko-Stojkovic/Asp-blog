using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Image;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Image;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.Image
{
    public class EfGetImageQuery : IGetImageQuery
    {
        private BlogDbContext _context;
        private GetImageValidator _validator;
        public EfGetImageQuery(BlogDbContext context, GetImageValidator validator)
        {
            _context = context;
            _validator = validator;

        }
        public int Id => 7;

        public string Name => "Get Image With Provided ID";

        public string Description => "Get Image With Provided ID";

        public ImageDTO Execute(int search)
        {
            Domain.Entities.Image image = _context.Images.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);

            var images = new ImageDTO
            {
                Id = image.Id,
                IsActive = image.IsActive,
                ImageUrl = image.ImageUrl,
                ImageSize = image.ImageSize
            };
            return (images);
        }
    }
}
