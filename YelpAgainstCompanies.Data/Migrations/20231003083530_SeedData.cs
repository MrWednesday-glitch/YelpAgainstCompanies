using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YelpAgainstCompanies.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Companies_CompanyId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Rating_UserId",
                table: "Rating");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Rating",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1cbb2c15-8a4d-4fb7-8cf7-08e723eb8007"), 0, "11cba2e2-52a3-4b6d-a357-43b52c192de3", "rowan@email.com", true, false, null, null, null, null, null, false, null, false, "rowan@email.com" },
                    { new Guid("b601d2b6-e80b-4f15-ae4b-a84d6488f4a5"), 0, "65253a72-7a05-4bd5-be98-95d142ddc379", "wednesday@asgard.com", true, false, null, null, null, null, null, false, null, false, "wednesday@asgard.com" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "Score" },
                values: new object[,]
                {
                    { 1, "Kees Balvert", 0.0 },
                    { 2, "Albert Heijn", 0.0 },
                    { 3, "Burger King", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Comment", "CompanyId", "Date", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, "Terrible Company!", 2, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.2000000000000002, new Guid("b601d2b6-e80b-4f15-ae4b-a84d6488f4a5") },
                    { 2, "It sucks to work here.", 2, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.75, new Guid("1cbb2c15-8a4d-4fb7-8cf7-08e723eb8007") },
                    { 3, "This job was fine.", 3, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.8999999999999999, new Guid("1cbb2c15-8a4d-4fb7-8cf7-08e723eb8007") },
                    { 4, "something", 1, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, new Guid("b601d2b6-e80b-4f15-ae4b-a84d6488f4a5") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Companies_CompanyId",
                table: "Rating",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Companies_CompanyId",
                table: "Rating");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1cbb2c15-8a4d-4fb7-8cf7-08e723eb8007"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b601d2b6-e80b-4f15-ae4b-a84d6488f4a5"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Rating",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Rating",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Companies_CompanyId",
                table: "Rating",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
