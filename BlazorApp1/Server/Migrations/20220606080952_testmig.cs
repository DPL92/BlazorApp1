using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    public partial class testmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_endId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_startId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_endId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_startId",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "endLlocationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "startLlocationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_endLlocationId",
                table: "Trips",
                column: "endLlocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_startLlocationId",
                table: "Trips",
                column: "startLlocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_endLlocationId",
                table: "Trips",
                column: "endLlocationId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_startLlocationId",
                table: "Trips",
                column: "startLlocationId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_endLlocationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_startLlocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_endLlocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_startLlocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "endLlocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "startLlocationId",
                table: "Trips");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_endId",
                table: "Trips",
                column: "endId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_startId",
                table: "Trips",
                column: "startId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_endId",
                table: "Trips",
                column: "endId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_startId",
                table: "Trips",
                column: "startId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
