using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Blog
{
    public class CreateBlogValidator : AbstractValidator<CreateBlogDTO>
    {
        public CreateBlogValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog Content is required.")
                                       .MinimumLength(5).WithMessage("Number of characters must be greater than 4.");
            RuleFor(x => x.UserId).NotEmpty().Must(x => context.Users.Any(y => y.Id == x && y.IsActive))
                                  .WithMessage("This User Doesn`t Exist In Database.");
            RuleFor(x => x.BlogImages).Must(x => x != null && x.Count > 0)
                                      .WithMessage("You Must Insert At Least One Photo")
                                      .Must(ImagesExistInDatabase)
                                      .WithMessage("This Image Doesn`t Exist In Database.");
            RuleFor(x => x.BlogTags).Must(TagsExistInDatabase)
                                    .WithMessage("This tag doesnt exists in database");



        }

        private bool ImagesExistInDatabase(ICollection<BlogImageDTO> blogImages)
        {
            BlogDbContext context = new BlogDbContext();
            if (blogImages == null || blogImages.Count == 0)
            {
                // Nema potrebe za proverom ako nema slika
                return true;
            }

            var imageIds = blogImages.Select(x => x.ImageId).ToList();

            // Provera da li postoji bar jedna slika sa ID-jem iz kolekcije imageIds
            return context.Images.Any(image => imageIds.Contains(image.Id));
        }
        private bool TagsExistInDatabase(ICollection<BlogTagDTO> blogTags)
        {
            BlogDbContext context = new BlogDbContext();
            if (blogTags == null || blogTags.Count == 0)
            {
                // Nema potrebe za proverom ako nema slika
                return true;
            }

            var tagIds = blogTags.Select(x => x.TagId).ToList();

            // Provera da li postoji bar jedna slika sa ID-jem iz kolekcije imageIds
            return context.Images.Any(tag => tagIds.Contains(tag.Id));
        }

    }
}
