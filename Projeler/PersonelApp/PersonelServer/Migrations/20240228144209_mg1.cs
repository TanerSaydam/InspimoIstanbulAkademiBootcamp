using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelServer.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "varchar(11)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    District = table.Column<string>(type: "varchar(50)", nullable: false),
                    FullAddress = table.Column<string>(type: "varchar(300)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiplomaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthReportUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_IdentityNumber",
                table: "Personels",
                column: "IdentityNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}
