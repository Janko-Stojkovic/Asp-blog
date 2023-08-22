using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Comment;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Comment
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private BlogDbContext _context;
        private IApplicationUser _user;
        private CreateCommentValidator _validator;

        public EfCreateCommentCommand(BlogDbContext context, IApplicationUser user, CreateCommentValidator validator)
        {
            _context = context;
            _user = user;
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Create Comment";

        public string Description => "Create Comment For Specified Blog";

        public void Execute(CreateCommentDTO request)
        {
            _validator.ValidateAndThrow(request);

            var comment = new Domain.Entities.Comment
            {
                ParentId = request.ParentId,
                BlogId = request.BlogId,
                CommentedAt = DateTime.UtcNow,
                CommentContent = request.Comment,
                UserId = _user.Id
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
