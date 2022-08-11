using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Domain
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; } 
        public string Email { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
