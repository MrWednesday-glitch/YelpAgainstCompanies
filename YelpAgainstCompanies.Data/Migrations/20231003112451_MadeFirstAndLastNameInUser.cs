using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YelpAgainstCompanies.Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeFirstAndLastNameInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c992957f-7b18-4b1a-8d53-5d3f5c99f726"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd598be7-974f-4e01-aba8-0e861915b2e5"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b45742d9-7c18-43a6-b61e-91b1334ac0fe"), 0, "2cf2773f-9882-49e5-a1c2-a5e4f0f71fbb", "wednesday@asgard.com", true, "Wednesday", null, false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("d4609d03-1a2e-49b0-9c76-2e832ba89287"), 0, "483a09ac-dc1a-442f-b566-d86c28b52518", "rowan@email.com", true, "Rowan", null, false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("b45742d9-7c18-43a6-b61e-91b1334ac0fe"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("d4609d03-1a2e-49b0-9c76-2e832ba89287"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: new Guid("d4609d03-1a2e-49b0-9c76-2e832ba89287"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: new Guid("b45742d9-7c18-43a6-b61e-91b1334ac0fe"));

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_UserId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_UserId",
                table: "Rating");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b45742d9-7c18-43a6-b61e-91b1334ac0fe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4609d03-1a2e-49b0-9c76-2e832ba89287"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("c992957f-7b18-4b1a-8d53-5d3f5c99f726"), 0, "a9ff4be4-a875-4ada-b6ae-4c4be96e9303", "wednesday@asgard.com", true, false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("fd598be7-974f-4e01-aba8-0e861915b2e5"), 0, "ca1fb920-7f90-4f30-930c-3aacb71f0b19", "rowan@email.com", true, false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("c992957f-7b18-4b1a-8d53-5d3f5c99f726"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("fd598be7-974f-4e01-aba8-0e861915b2e5"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: new Guid("fd598be7-974f-4e01-aba8-0e861915b2e5"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: new Guid("c992957f-7b18-4b1a-8d53-5d3f5c99f726"));
        }
    }
}
