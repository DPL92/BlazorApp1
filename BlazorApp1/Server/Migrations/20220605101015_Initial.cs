using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    driverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    license = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.driverId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    vehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    licensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seats = table.Column<int>(type: "int", nullable: false),
                    requiredDL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.vehicleId);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "driverId", "driverFirstName", "driverLastName", "license" },
                values: new object[,]
                {
                    { 1, "Dominik", "Lugmair", "B" },
                    { 2, "Max", "Sieber", "B" },
                    { 3, "Karla", "Fuchs", "BCD" },
                    { 4, "Marlene", "Feuchtinger", "BF" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "vehicleId", "licensePlate", "manufacturer", "model", "requiredDL", "seats" },
                values: new object[,]
                {
                    { 1, "L-290ND", "Renault", "Megane", "B", 5 },
                    { 2, "L-123AB", "VW", "T6", "B", 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
