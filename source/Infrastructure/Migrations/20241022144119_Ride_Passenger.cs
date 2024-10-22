using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ride_Passenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "Rides",
                type: "INTEGER",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_PassengerId",
                table: "Rides",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Passengers_PassengerId",
                table: "Rides",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Passengers_PassengerId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_PassengerId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Rides");
        }
    }
}
