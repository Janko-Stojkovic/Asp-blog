using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Comment;
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
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private BlogDbContext _context;
        private DeleteCommentValidator _validator;
        private readonly IApplicationUser _user;
        public EfDeleteCommentCommand(BlogDbContext context, DeleteCommentValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 29;

        public string Name => "Brisanje komentara";

        public string Description => "Brisanje komentara";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var data = _context.Comments.Find(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;
            data.DeletedBy = _user.Username;
            _context.SaveChanges();
        }
    }
}
