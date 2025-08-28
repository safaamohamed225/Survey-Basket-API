using SurveyBasket.Abstractions.Consts;

namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .OwnsMany(x => x.RefreshTokens)
            .ToTable("RefreshTokens")
            .WithOwner()
            .HasForeignKey("UserId");
            
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);

        //var passwordHasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(new ApplicationUser
        {
            Id = DefaultUsers.AdminId,
            FirstName = "Safa",
            LastName = "Muhammad",
            Email = DefaultUsers.AdminEmail,
            EmailConfirmed = true,
            NormalizedUserName = DefaultUsers.AdminEmail.ToUpper(),
            NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
            SecurityStamp = DefaultUsers.AdminEmail,
            ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
            //PasswordHash = passwordHasher.HashPassword(null!, DefaultUsers.AdminPassword)
            PasswordHash = DefaultUsers.AdminPasswordHash
        });
    }

}
