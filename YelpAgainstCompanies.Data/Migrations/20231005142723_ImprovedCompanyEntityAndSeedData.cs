using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YelpAgainstCompanies.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedCompanyEntityAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b45742d9-7c18-43a6-b61e-91b1334ac0fe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4609d03-1a2e-49b0-9c76-2e832ba89287"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("62190e60-1e32-444a-a55a-94005b6622b7"), 0, "fb03eeac-3db0-40ce-bd26-62b37f6f2995", "wednesday@asgard.com", true, "Wednesday", "Y", false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("71b95c46-2b82-4f73-8092-3ba6f3aeb49d"), 0, "571f127f-6823-4a28-93b3-1271ae396ad6", "rowan@email.com", true, "Rowan", "X", false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "PictureUrl", "PostalCode", "Score" },
                values: new object[] { "Street 5", "Den Haag", "https://cdn.autotrack.nl/18126/0-438b7d7d-c717-484c-b4a7-81e6a4df20ae.jpg?w=320", "1234XD", 3.0 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "PictureUrl", "PostalCode", "Score" },
                values: new object[] { "Dorpstraat 3", "Zoetermeer", "https://media.prdn.nl/retailtrends/files/RetailTrends/Albert+Heijn+5.jpg", "2345RT", 1.9750000000000001 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "PictureUrl", "PostalCode", "Score" },
                values: new object[] { "Kaaglaan 66", "Den Haag", "https://st3.idealista.com/news/archivos/styles/imagen_big_lightbox/public/2020-03/burger_king.jpg?sv=TGX70G_u&itok=fWgVKuuM", "6666YY", 3.8999999999999999 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62190e60-1e32-444a-a55a-94005b6622b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71b95c46-2b82-4f73-8092-3ba6f3aeb49d"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b45742d9-7c18-43a6-b61e-91b1334ac0fe"), 0, "2cf2773f-9882-49e5-a1c2-a5e4f0f71fbb", "wednesday@asgard.com", true, "Wednesday", null, false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("d4609d03-1a2e-49b0-9c76-2e832ba89287"), 0, "483a09ac-dc1a-442f-b566-d86c28b52518", "rowan@email.com", true, "Rowan", null, false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Score",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Score",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Score",
                value: 0.0);

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
        }
    }
}
