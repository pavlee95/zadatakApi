using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.Commands;
using Zadatak.Application.DataTransfer;
using Zadatak.Application.Exceptions;
using Zadatak.Domain;
using Zadatak.EFDataAccess;
using Zadatak.Implementation.Validators;

namespace Zadatak.Implementation.Commands
{
    public class EFEditRoleCommand : IEditRoleCommand
    {
        private readonly ZadatakContext _context;
        private readonly UpdateRoleValidator _validator;

        public EFEditRoleCommand(ZadatakContext context, UpdateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Edit role using EF";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var id = request.Id;
            var x = _context.Roles.Find(id);
            x.Name = request.Name;
            _context.SaveChanges();
            
        }
    }
}
