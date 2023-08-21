using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab8UsersAndRoles.Models;

namespace Lab8UsersAndRoles.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Lab8UsersAndRoles.Models.ApplicationRole> ApplicationRole { get; set; } = default!;
        public DbSet<Lab8UsersAndRoles.Models.Product> Product { get; set; } = default!;
        public DbSet<Lab8UsersAndRoles.Models.Cartitem> Cartitem { get; set; } = default!;
    }
}