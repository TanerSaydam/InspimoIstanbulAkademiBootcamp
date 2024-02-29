using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonelServer.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d4a950d-269b-4aaa-bbd1-32b6832d3cf8"), "Frontend Developer" },
                    { new Guid("18b44f34-a078-4fc0-9ee1-5e5c7b0b1ceb"), "Full Stack Developer" },
                    { new Guid("36745468-c99a-483c-b57e-08bfe168fd64"), "Software Developer" },
                    { new Guid("50edf3c8-089f-481e-a389-0450c18834d3"), "Teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: new Guid("0d4a950d-269b-4aaa-bbd1-32b6832d3cf8"));

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: new Guid("18b44f34-a078-4fc0-9ee1-5e5c7b0b1ceb"));

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: new Guid("36745468-c99a-483c-b57e-08bfe168fd64"));

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: new Guid("50edf3c8-089f-481e-a389-0450c18834d3"));
        }
    }
}
