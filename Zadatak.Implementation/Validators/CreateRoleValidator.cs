using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.DataTransfer;
using Zadatak.EFDataAccess;

namespace Zadatak.Implementation.Validators
{
    public class CreateRoleValidator : AbstractValidator<RoleDto>
    {
        public CreateRoleValidator(ZadatakContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(n => !context.Roles.Any(r => r.Name ==n))
                .WithMessage("Role name must be unique!");
        }
    }
}
