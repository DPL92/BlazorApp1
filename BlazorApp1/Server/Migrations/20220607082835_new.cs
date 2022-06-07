using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "endId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "endLlocationId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "startLlocationId",
                table: "Trips",
                newName: "startLId");

            migrationBuilder.RenameColumn(
                name: "startId",
                table: "Trips",
                newName: "endLId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_startLlocationId",
                table: "Trips",
                newName: "IX_Trips_startLId");

            migrationBuilder.AlterColumn<int>(
                name: "duration",
                table: "Trips",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_endLId",
                table: "Trips",
                column: "endLId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_endLId",
                table: "Trips",
                column: "endLId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_startLId",
                table: "Trips",
                column: "startLId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_endLId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_startLId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_endLId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "startLId",
                table: "Trips",
                newName: "startLlocationId");

            migrationBuilder.RenameColumn(
                name: "endLId",
                table: "Trips",
                newName: "startId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_startLId",
                table: "Trips",
                newName: "IX_Trips_startLlocationId");

            migrationBuilder.AlterColumn<double>(
                name: "duration",
                table: "Trips",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "endId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "endLlocationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_endLlocationId",
                table: "Trips",
                column: "endLlocationId");

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
    }
}
