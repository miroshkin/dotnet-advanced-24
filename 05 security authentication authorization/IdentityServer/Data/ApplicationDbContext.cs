using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            // Seed roles and permissions
            var managerRole = new IdentityRole { Id = "1", Name = "Manager", NormalizedName = "MANAGER" };
            var buyerRole = new IdentityRole { Id = "2", Name = "Buyer", NormalizedName = "BUYER" };

            builder.Entity<IdentityRole>().HasData(managerRole, buyerRole);

            // Seed users
            var hasher = new PasswordHasher<ApplicationUser>();

            var managerUser = new ApplicationUser
            {
                Id = "1",
                UserName = "manager@domain.com",
                NormalizedUserName = "MANAGER@DOMAIN.COM",
                Email = "manager@domain.com",
                NormalizedEmail = "MANAGER@DOMAIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            var buyerUser = new ApplicationUser
            {
                Id = "2",
                UserName = "buyer@domain.com",
                NormalizedUserName = "BUYER@DOMAIN.COM",
                Email = "buyer@domain.com",
                NormalizedEmail = "BUYER@DOMAIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            builder.Entity<ApplicationUser>().HasData(managerUser, buyerUser);

            // Assign roles to users
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = managerUser.Id, RoleId = managerRole.Id },
                new IdentityUserRole<string> { UserId = buyerUser.Id, RoleId = buyerRole.Id });

            // Seed claims
            builder.Entity<IdentityRoleClaim<string>>().HasData(
                new IdentityRoleClaim<string> { Id = 1, RoleId = managerRole.Id, ClaimType = "Permission", ClaimValue = "Read" },
                new IdentityRoleClaim<string> { Id = 2, RoleId = managerRole.Id, ClaimType = "Permission", ClaimValue = "Create" },
                new IdentityRoleClaim<string> { Id = 3, RoleId = managerRole.Id, ClaimType = "Permission", ClaimValue = "Update" },
                new IdentityRoleClaim<string> { Id = 4, RoleId = managerRole.Id, ClaimType = "Permission", ClaimValue = "Delete" },
                new IdentityRoleClaim<string> { Id = 5, RoleId = buyerRole.Id, ClaimType = "Permission", ClaimValue = "Read" }
            );
        }
    }
}
