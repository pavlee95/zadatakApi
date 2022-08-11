using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.DataTransfer;
using Zadatak.Application.Queries;
using Zadatak.EFDataAccess;

namespace Zadatak.Implementation.Queries
{
    public class EFGetRolesQuery : IGetRolesQuery
    {
        private readonly ZadatakContext _context;

        public EFGetRolesQuery(ZadatakContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Role search using EF";

        public IEnumerable<RoleDto> Execute(RoleSearch search)
        {
            var query = _context.Roles.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name)) 
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return query.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
