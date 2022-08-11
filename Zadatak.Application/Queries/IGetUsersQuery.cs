using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application.DataTransfer;

namespace Zadatak.Application.Queries
{
    public interface IGetUsersQuery : IQuery<UserSearch, IEnumerable<UserDto>>
    {
        
    }
}
