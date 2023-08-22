using ASP_Projekat.Application.Emails;
using ASP_Projekat.Application.UseCases.Commands.User;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using ASP_Projekat.Domain.Entities;
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
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private BlogDbContext _context;
        private CreateUserValidator _validator;
        private IEmailSender _sender;

        public EfCreateUserCommand(BlogDbContext context, CreateUserValidator validator, IEmailSender sender) : base(context)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 17;

        public string Name => "User Registration";

        public string Description => "User Registration";

        public void Execute(CreateUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var hashPass = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new Domain.Entities.User();

            if (!string.IsNullOrEmpty(request.ImageFileName))
            {
                var image = new Domain.Entities.Image() { ImageUrl = request.ImageFileName, ImageSize = 50 };

                user.Email = request.Email;
                user.Username = request.Username;
                user.Password = hashPass;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.ProfileImageId = image.Id;
                user.RoleId = 2;
                user.Image = image;

            }
            else
            {
                user.Email = request.Email;
                user.Username = request.Username;
                user.Password = hashPass;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.RoleId = 2;
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            //_sender.Send(new EmailDTO
            //{
            //    From = "noreply-asp@ict.edu.rs",
            //    To = request.Email,
            //    Title = "Confirm Registration",
            //    Body = "Dear " + request.Username + "\n Please activate your account...."
            //});

        }
    }
}
