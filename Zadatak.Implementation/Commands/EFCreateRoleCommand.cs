using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.Commands;
using Zadatak.Application.DataTransfer;
using Zadatak.Domain;
using Zadatak.EFDataAccess;
using Zadatak.Implementation.Validators;

namespace Zadatak.Implementation.Commands
{
    public class EFCreateRoleCommand : ICreateRoleCommand
    {
        private readonly ZadatakContext _context;
        private readonly CreateRoleValidator _validator;

        public EFCreateRoleCommand(ZadatakContext context, CreateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create new role using EF";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = new Role
            {
                Name = request.Name
            };

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
