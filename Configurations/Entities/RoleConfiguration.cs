using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eServicesApi.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR".ToUpper()
                 },
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7220",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER".ToUpper(),
                }
                );
        }
    }
}
