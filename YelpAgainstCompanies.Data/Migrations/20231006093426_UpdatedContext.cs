using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YelpAgainstCompanies.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62190e60-1e32-444a-a55a-94005b6622b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71b95c46-2b82-4f73-8092-3ba6f3aeb49d"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3e4b73a2-984a-49dd-83e5-fd94c2464175"), 0, "600372dd-095f-40bb-a3e9-f1da60af98f4", "wednesday@asgard.com", true, "Wednesday", "Y", false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("696259f1-3909-4807-b8b3-46c0f2b32afb"), 0, "044bb725-25f0-4f36-84b2-625bf3c2e3e6", "rowan@email.com", true, "Rowan", "X", false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("3e4b73a2-984a-49dd-83e5-fd94c2464175"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("696259f1-3909-4807-b8b3-46c0f2b32afb"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: new Guid("696259f1-3909-4807-b8b3-46c0f2b32afb"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: new Guid("3e4b73a2-984a-49dd-83e5-fd94c2464175"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e4b73a2-984a-49dd-83e5-fd94c2464175"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("696259f1-3909-4807-b8b3-46c0f2b32afb"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("62190e60-1e32-444a-a55a-94005b6622b7"), 0, "fb03eeac-3db0-40ce-bd26-62b37f6f2995", "wednesday@asgard.com", true, "Wednesday", "Y", false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("71b95c46-2b82-4f73-8092-3ba6f3aeb49d"), 0, "571f127f-6823-4a28-93b3-1271ae396ad6", "rowan@email.com", true, "Rowan", "X", false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("62190e60-1e32-444a-a55a-94005b6622b7"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("71b95c46-2b82-4f73-8092-3ba6f3aeb49d"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: new Guid("71b95c46-2b82-4f73-8092-3ba6f3aeb49d"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: new Guid("62190e60-1e32-444a-a55a-94005b6622b7"));
        }
    }
}
