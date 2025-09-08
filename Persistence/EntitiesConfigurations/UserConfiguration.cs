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

        builder.HasData(new ApplicationUser
        {
            Id = DefaultUsers.Admin.Id,
            FirstName = "Safa",
            LastName = "Muhammad",
            Email = DefaultUsers.Admin.Email,
            EmailConfirmed = true,
            NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
            NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Admin.Email,
            ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
            PasswordHash = DefaultUsers.Admin.PasswordHash
        });
    }
}
