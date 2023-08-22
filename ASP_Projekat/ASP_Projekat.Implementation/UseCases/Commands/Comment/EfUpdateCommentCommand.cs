using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Comment;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Comment;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Comment
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private BlogDbContext _context;
        private UpdateCommentValidator _validator;
        private readonly IApplicationUser _user;
        public EfUpdateCommentCommand(BlogDbContext context, UpdateCommentValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
            
        }
        public int Id => 31;

        public string Name => "Edit Comment";

        public string Description => "Edit Comment";

        public void Execute(UpdateCommentDTO request)
        {
            _validator.ValidateAndThrow(request);
            var comment = _context.Comments.Find(request.Id);

            comment.CommentContent = request.Comment;
            comment.UpdatedAt = DateTime.UtcNow;
            comment.UpdatedBy = _user.Username;
            _context.Entry(comment).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
