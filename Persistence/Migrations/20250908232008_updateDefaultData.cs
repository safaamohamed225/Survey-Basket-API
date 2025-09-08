using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Migrations
{
    /// <inheritdoc />
    public partial class updateDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01992b94-c90c-73d6-8ab6-57da7b94c8a1", "01992b94-c90c-7b5a-bfbb-e408a13be22b", true, false, "Member", "MEMBER" },
                    { "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5", "01992b94-c90c-76b1-8c5e-d4f0169e6958", false, false, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01992b94-c90c-7d9a-a775-44fabce80885", 0, "01992b94-c90c-7dda-b4a6-a748c17cce14", "admin@role.com", true, "Safa", false, "Muhammad", false, null, "ADMIN@ROLE.COM", "ADMIN@ROLE.COM", "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==", null, false, "admin@role.com", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5", "01992b94-c90c-7d9a-a775-44fabce80885" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01992b94-c90c-73d6-8ab6-57da7b94c8a1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5", "01992b94-c90c-7d9a-a775-44fabce80885" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01992b94-c90c-7e8f-bce6-ea79c9f5b3c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01992b94-c90c-7d9a-a775-44fabce80885");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "0198dc42-e2ee-73cc-9237-12f4c152c332");

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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0198d5c2-4e9d-713a-aa78-e6853aee4737", 0, "0198d5cb-b811-7192-8357-d513ae755b25", "admin@role.com", true, "Safa", false, "Muhammad", false, null, "ADMIN@ROLE.COM", "ADMIN@ROLE.COM", "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==", null, false, "admin@role.com", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0198dc42-e2ee-73cc-9237-12f4c152c332", "0198d5c2-4e9d-713a-aa78-e6853aee4737" });
        }
    }
}
