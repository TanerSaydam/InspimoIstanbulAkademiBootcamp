using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBiletServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    from = table.Column<string>(type: "text", nullable: false),
                    to = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    otobus_id = table.Column<Guid>(type: "uuid", nullable: false),
                    buses_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routes", x => x.id);
                    table.ForeignKey(
                        name: "fk_routes_buses_buses_id",
                        column: x => x.buses_id,
                        principalTable: "buses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_routes_buses_id",
                table: "routes",
                column: "buses_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routes");
        }
    }
}
