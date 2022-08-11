using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Domain;
using Zadatak.EFDataAccess.Configurations;

namespace Zadatak.EFDataAccess
{
    public class ZadatakContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Editor"
                },
                new Role
                {
                    Id = 3,
                    Name = "Subscriber"
                }
            };
            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());


            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=ASUS-K550V;Initial Catalog=Termin7;Integrated Security=True");
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\spaso\source\repos\Zadatak\Zadatak.EFDataAccess\zadatak.db;Cache=Shared");
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

    }
}
