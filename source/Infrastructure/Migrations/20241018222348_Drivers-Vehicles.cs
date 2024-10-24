using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DriversVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverVehicle",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "INTEGER", nullable: false),
                    _vehiclesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVehicle", x => new { x.DriversId, x._vehiclesId });
                    table.ForeignKey(
                        name: "FK_DriverVehicle_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverVehicle_Vehicles__vehiclesId",
                        column: x => x._vehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverVehicle__vehiclesId",
                table: "DriverVehicle",
                column: "_vehiclesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverVehicle");
        }
    }
}
