using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Blog
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogDTO>
    {
        private BlogDbContext _context;
        public UpdateBlogValidator(BlogDbContext context)
        {
            _context = context;
            RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.BlogContent)
            .NotEmpty().WithMessage("Blog content is required.")
            .MaximumLength(500).WithMessage("Blog content cannot exceed 500 characters.");

        RuleFor(x => x)
             .Must( blog => BlogContentIsUnique(blog.Id, blog.BlogContent))
            .WithMessage("A blog with the same content already exists.");
        }

        private bool BlogContentIsUnique(int blogId, string blogContent)
        {

            // Proverite da li postoji drugi blog sa istim sadržajem, osim ako je isti blog koji se ažurira.
            var existingBlog = _context.Blogs
                .FirstOrDefault(blog => blog.BlogContent == blogContent && blog.Id != blogId);

            return existingBlog == null;
        }
    }
}
