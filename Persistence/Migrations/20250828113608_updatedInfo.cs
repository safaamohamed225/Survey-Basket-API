using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Migrations
{
    /// <inheritdoc />
    public partial class updatedInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0198d5c2-4e9d-713a-aa78-e6853aee4737",
                columns: new[] { "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "admin@role.com", "Safa", "Muhammad", "ADMIN@ROLE.COM", "ADMIN@ROLE.COM", "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==", "admin@role.com", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0198d5c2-4e9d-713a-aa78-e6853aee4737",
                columns: new[] { "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "admin@survey-basket.com", "Survey Basket", "Admin", "ADMIN@SURVEY-BASKET.COM", "ADMIN@SURVEY-BASKET.COM", "P@ssword123", "24762FF6-A857-4409-9F31-D7F7CDEA4F0D", "admin@survey-basket.com" });
        }
    }
}
