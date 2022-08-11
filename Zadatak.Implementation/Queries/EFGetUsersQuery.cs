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
    public class EFGetUsersQuery : IGetUsersQuery
    {
        private readonly ZadatakContext _context;

        public EFGetUsersQuery(ZadatakContext context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "All User search using EF";

        public IEnumerable<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
            {
                query = query.Where(x => x.UserName.ToLower().Contains(search.UserName.ToLower()));
            }
            return query.Select(x => new UserDto
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();
        }
    }
}
