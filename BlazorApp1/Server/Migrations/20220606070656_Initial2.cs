using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postalCode = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    houseNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locationId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    tripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    startId = table.Column<int>(type: "int", nullable: false),
                    endId = table.Column<int>(type: "int", nullable: false),
                    vehicleId = table.Column<int>(type: "int", nullable: false),
                    startLlocationId = table.Column<int>(type: "int", nullable: false),
                    endLlocationId = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<double>(type: "float", nullable: false),
                    finished = table.Column<bool>(type: "bit", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.tripId);
                    table.ForeignKey(
                        name: "FK_Trips_Drivers_driverId",
                        column: x => x.driverId,
                        principalTable: "Drivers",
                        principalColumn: "driverId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Trips_Locations_endLlocationId",
                        column: x => x.endLlocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Trips_Locations_startLlocationId",
                        column: x => x.startLlocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Trips_Vehicles_vehicleId",
                        column: x => x.vehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "vehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "locationId", "country", "houseNr", "locationName", "postalCode", "street" },
                values: new object[] { 1, "AUT", 82, "Linz", 4030, "Prechtlerstrasse" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "locationId", "country", "houseNr", "locationName", "postalCode", "street" },
                values: new object[] { 2, "AUT", 69, "Linz", 4040, "Altenbergerstrasse" });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_driverId",
                table: "Trips",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_endLlocationId",
                table: "Trips",
                column: "endLlocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_startLlocationId",
                table: "Trips",
                column: "startLlocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_vehicleId",
                table: "Trips",
                column: "vehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
