using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Migrations
{
    /// <inheritdoc />
    public partial class SeedingIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0198dc42-e2ee-73cc-9237-12f4c152c332", "0198dc44-2966-79a2-808a-a828fa857801", false, false, "Admin", "ADMIN" },
                    { "0198dc44-e6dd-7f0d-9d74-b7bbad512ce4", "0198dc45-0c6a-7e68-ad05-7dfb254fb6d3", true, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0198d5c2-4e9d-713a-aa78-e6853aee4737", 0, "0198d5cb-b811-7192-8357-d513ae755b25", "admin@role.com", true, "Safa", "Muhammad", false, null, "ADMIN@ROLE.COM", "ADMIN@ROLE.COM", "AQAAAAIAAYagAAAAEE7xUY5Oc5NlksdDtoox1tNcyPOdSzvwGz6pWa4Aa4BzmNraMZ7VKsh7/K4lvCrfOg==", null, false, "admin@role.com", false, null });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "Polls : read", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 2, "Permission", "Polls : add", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 3, "Permission", "Polls : update", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 4, "Permission", "Polls : remove", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 5, "Permission", "Questions : read", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 6, "Permission", "Questions : add", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 7, "Permission", "Questions : update", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 8, "Permission", "Users : read", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 9, "Permission", "Users : add", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 10, "Permission", "Users : update", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 11, "Permission", "Roles : read", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 12, "Permission", "Roles : add", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 13, "Permission", "Roles : update", "0198dc42-e2ee-73cc-9237-12f4c152c332" },
                    { 14, "Permission", "Results : read", "0198dc42-e2ee-73cc-9237-12f4c152c332" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0198dc42-e2ee-73cc-9237-12f4c152c332", "0198d5c2-4e9d-713a-aa78-e6853aee4737" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0198dc44-e6dd-7f0d-9d74-b7bbad512ce4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0198dc42-e2ee-73cc-9237-12f4c152c332", "0198d5c2-4e9d-713a-aa78-e6853aee4737" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0198d5c2-4e9d-713a-aa78-e6853aee4737");
        }
    }
}
