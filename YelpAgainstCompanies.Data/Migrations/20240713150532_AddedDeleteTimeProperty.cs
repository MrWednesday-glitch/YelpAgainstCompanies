using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YelpAgainstCompanies.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeleteTimeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("15782a7b-447b-408e-9de9-57f74c1d0463"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5fa0aae-fa8e-4a09-b578-006df89aa22f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Rating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0b1ce315-52b1-4474-9b5b-2494f2c055bd"), 0, "b4ae6c14-0714-40c5-a1f3-5ff8ce9387d8", "rowan@email.com", true, "Rowan", "X", false, null, null, null, null, null, false, null, false, "rowan@email.com" },
                    { new Guid("d33d393d-b461-4ff2-8851-3e5e650524fa"), 0, "2d008893-79c1-4b5f-9717-36cc7d387901", "wednesday@asgard.com", true, "Wednesday", "Y", false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeletedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeletedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeletedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedDate", "UserId" },
                values: new object[] { null, new Guid("d33d393d-b461-4ff2-8851-3e5e650524fa") });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeletedDate", "UserId" },
                values: new object[] { null, new Guid("0b1ce315-52b1-4474-9b5b-2494f2c055bd") });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeletedDate", "UserId" },
                values: new object[] { null, new Guid("0b1ce315-52b1-4474-9b5b-2494f2c055bd") });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeletedDate", "UserId" },
                values: new object[] { null, new Guid("d33d393d-b461-4ff2-8851-3e5e650524fa") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b1ce315-52b1-4474-9b5b-2494f2c055bd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d33d393d-b461-4ff2-8851-3e5e650524fa"));

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("15782a7b-447b-408e-9de9-57f74c1d0463"), 0, "ec2ee74c-9911-4691-b2cd-66046841f176", "wednesday@asgard.com", true, "Wednesday", "Y", false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" },
                    { new Guid("a5fa0aae-fa8e-4a09-b578-006df89aa22f"), 0, "14822904-12c1-4313-8c82-81ebdfc47efa", "rowan@email.com", true, "Rowan", "X", false, null, null, null, null, null, false, null, false, "rowan@email.com" }
                });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("15782a7b-447b-408e-9de9-57f74c1d0463"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("a5fa0aae-fa8e-4a09-b578-006df89aa22f"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: new Guid("a5fa0aae-fa8e-4a09-b578-006df89aa22f"));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: new Guid("15782a7b-447b-408e-9de9-57f74c1d0463"));
        }
    }
}
