using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBiletServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_routes_buses_buses_id",
                table: "routes");

            migrationBuilder.DropIndex(
                name: "ix_routes_buses_id",
                table: "routes");

            migrationBuilder.DropColumn(
                name: "buses_id",
                table: "routes");

            migrationBuilder.RenameColumn(
                name: "otobus_id",
                table: "routes",
                newName: "bus_id");

            migrationBuilder.CreateIndex(
                name: "ix_routes_bus_id",
                table: "routes",
                column: "bus_id");

            migrationBuilder.AddForeignKey(
                name: "fk_routes_buses_bus_id",
                table: "routes",
                column: "bus_id",
                principalTable: "buses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_routes_buses_bus_id",
                table: "routes");

            migrationBuilder.DropIndex(
                name: "ix_routes_bus_id",
                table: "routes");

            migrationBuilder.RenameColumn(
                name: "bus_id",
                table: "routes",
                newName: "otobus_id");

            migrationBuilder.AddColumn<Guid>(
                name: "buses_id",
                table: "routes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_routes_buses_id",
                table: "routes",
                column: "buses_id");

            migrationBuilder.AddForeignKey(
                name: "fk_routes_buses_buses_id",
                table: "routes",
                column: "buses_id",
                principalTable: "buses",
                principalColumn: "id");
        }
    }
}
