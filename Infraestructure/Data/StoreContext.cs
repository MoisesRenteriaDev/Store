using Core.Entities;
using Infraestructure.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class StoreContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        }
    }
}