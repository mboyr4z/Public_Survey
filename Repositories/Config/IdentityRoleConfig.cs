using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "Author", NormalizedName = "AUTHOR"},
                new IdentityRole() { Name = "Boss", NormalizedName = "BOSS" },
                new IdentityRole() { Name = "Commentator", NormalizedName = "COMMENTATOR" }
                
            );
        }

    }
}