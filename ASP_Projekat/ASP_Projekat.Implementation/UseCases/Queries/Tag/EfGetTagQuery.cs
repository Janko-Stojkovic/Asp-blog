using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Tag;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Tag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.Tag
{
    public class EfGetTagQuery : IGetTagQuery
    {
        private BlogDbContext _context;
        private GetTagValidator _validator;
        private readonly IApplicationUser _user;

        public int Id => 3;

        public string Name => "Get Tag With Provided ID";
        public string Description => "Get Tag With Provided ID";

        public EfGetTagQuery(BlogDbContext context, GetTagValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public TagDTO Execute(int search)
        {
            Domain.Entities.Tag tag = _context.Tags.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);

            var tags = new TagDTO
            {
                Id = tag.Id,
                Tag = tag.TagText
            };
            return (tags);
        }
    }
}
