using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(item => item.HasKey(x => new { x.AppUserId, x.StockId }));

            builder
                .Entity<Portfolio>()
                .HasOne(item => item.AppUser)
                .WithMany(item => item.Portfolios)
                .HasForeignKey(item => item.AppUserId);

            builder
                .Entity<Portfolio>()
                .HasOne(item => item.Stock)
                .WithMany(item => item.Portfolios)
                .HasForeignKey(item => item.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
