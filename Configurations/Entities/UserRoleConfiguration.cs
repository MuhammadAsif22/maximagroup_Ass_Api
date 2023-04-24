using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eServicesApi.Configurations.Entities
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            //Default Role for Admin & User 
            builder.HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                     UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                 },
                 new IdentityUserRole<string>
                 {
                     RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7220",
                     UserId = "b74ddd14-6340-4840-95c2-db12554843e7"
                 }
                );
        }
    }
}
