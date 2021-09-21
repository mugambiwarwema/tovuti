using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using tovuti.Authorization.Roles;
using tovuti.Authorization.Users;
using tovuti.MultiTenancy;
using Abp.Localization;
using Engine.Core;

namespace tovuti.EntityFrameworkCore
{
    public class tovutiDbContext : AbpZeroDbContext<Tenant, Role, User, tovutiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductTypeAttributeValue> ProductTypeAttributeValues { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

        public tovutiDbContext(DbContextOptions<tovutiDbContext> options)
            : base(options)
        {
        }

        // add these lines to override max length of property
        // we should set max length smaller than the PostgreSQL allowed size (10485760)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
    }
}
