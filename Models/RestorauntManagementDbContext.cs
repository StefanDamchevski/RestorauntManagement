using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RestorauntManagement.Models
{
    public class RestorauntManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public RestorauntManagementDbContext(DbContextOptions<RestorauntManagementDbContext> options) : base(options) {}

        public DbSet<Table> Tables { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ProductRecepit> ProductRecepits { get; set; }
    }
}
