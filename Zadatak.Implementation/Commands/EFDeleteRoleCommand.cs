using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.Commands;
using Zadatak.Application.Exceptions;
using Zadatak.Domain;
using Zadatak.EFDataAccess;

namespace Zadatak.Implementation.Commands
{
    public class EFDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly ZadatakContext _context;

        public EFDeleteRoleCommand(ZadatakContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Deleting role using EF";

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);
            if (role == null)
            {
                throw new EntityNotFoundException(request, typeof(Role));
            }
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
