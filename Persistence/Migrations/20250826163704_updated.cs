using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0198d5c2-4e9d-713a-aa78-e6853aee4737",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDsLHfGoe9AhQpCqPO+tSGL5wMevGT2u/GDMj6JOb1U4jGDItAoBzvzmoMKPr/I9Rg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0198d5c2-4e9d-713a-aa78-e6853aee4737",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEE7xUY5Oc5NlksdDtoox1tNcyPOdSzvwGz6pWa4Aa4BzmNraMZ7VKsh7/K4lvCrfOg==");
        }
    }
}
