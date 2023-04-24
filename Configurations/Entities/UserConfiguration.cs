using eServicesApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace eServicesApi.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new List<ApplicationUser>();

            ApplicationUser Admin = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "048555555"
            };

            
            Admin.PasswordHash = passwordHasher.HashPassword(null, "Admin*123");
            users.Add(Admin);

            ApplicationUser Customer = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e7",
                UserName = "customer@gmail.com",
                NormalizedUserName = "CUSTOMER@GMAIL.COM",
                Email = "customer@gmail.com",
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                PasswordHash = "sdffds",
                LockoutEnabled = false,
                PhoneNumber = "050555555"
            };

            Customer.PasswordHash = passwordHasher.HashPassword(null, "Customer*123");
            users.Add(Customer);

            builder.HasData(users);


        }



    }
}
