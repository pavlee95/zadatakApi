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
    public class UpdateRoleValidator : AbstractValidator<RoleDto>
    {
        public UpdateRoleValidator(ZadatakContext context)
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required parameter")
            .Must((dto, name) => !context.Roles.Any(p => p.Name == name && p.Id != dto.Id))
            .WithMessage(p => $"Role with same name {p.Name} already exist.");
        }
    }
}
