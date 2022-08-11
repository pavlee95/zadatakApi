using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.Commands;
using Zadatak.Application.DataTransfer;
using Zadatak.Application.Email;
using Zadatak.EFDataAccess;
using Zadatak.Implementation.Validators;

namespace Zadatak.Implementation.Commands
{
    public class EFRegisterUserCommand : IRegisterUserCommand
    {
        private readonly ZadatakContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EFRegisterUserCommand(ZadatakContext context, RegisterUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 4;

        public string Name => "User Registration";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email
            });
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1> Successful registration</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
