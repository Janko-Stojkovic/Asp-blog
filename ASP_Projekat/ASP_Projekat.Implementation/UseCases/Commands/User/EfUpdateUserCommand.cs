using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.User;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.User;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.User
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private BlogDbContext _context;
        private UpdateUserValidator _validator;
        private readonly IApplicationUser _user;

        public EfUpdateUserCommand(BlogDbContext context, UpdateUserValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 18;

        public string Name => "Update User";

        public string Description => "Update User";

        public void Execute(UpdateUserDTO request)
        {
           
                _validator.ValidateAndThrow(request);

                var user = _context.Users.Find(request.Id);

                var updated = 0;

                if (!string.IsNullOrEmpty(request.Email))
                {
                    user.Email = request.Email;
                    updated++;
                }

                if (!string.IsNullOrEmpty(request.Password))
                {
                    var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    user.Password = hash;
                    updated++;
                }

                if (!string.IsNullOrEmpty(request.Username))
                {
                    user.Username = request.Username;
                    updated++;
                }

                if (request.ProfileImageId != null)
                {
                    user.ProfileImageId = request.ProfileImageId;
                    updated++;
                }
            if (updated > 0)
            {
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedBy = _user.Username;
                _context.Entry(user).State = EntityState.Modified;

                _context.SaveChanges();
            }
   
        }
    }
}
