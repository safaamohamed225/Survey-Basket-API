using SurveyBasket.Abstractions.Consts;

namespace SurveyBasket.Persistence
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            var permissions = Permissions.GetAllPermissions();
            var adminClaims = new List<IdentityRoleClaim<string>>();
            for(var i = 0; i < permissions.Count; i++)
            {
                adminClaims.Add(new IdentityRoleClaim<string>
                {
                    Id = i + 1,
                    RoleId = DefaultRoles.AdminRoleId,
                    ClaimType = Permissions.Type,
                    ClaimValue = permissions[i]!
                });
            }

            builder.HasData(adminClaims);
        }
    }
}
