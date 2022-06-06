namespace BlazorApp1.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                 new Vehicle { vehicleId = 1, licensePlate = "L-290ND", manufacturer = "Renault", model = "Megane", requiredDL = "B", seats = 5 },
            new Vehicle { vehicleId = 2, licensePlate = "L-123AB", manufacturer = "VW", model = "T6", requiredDL = "B", seats = 8 }
                );


            modelBuilder.Entity<Driver>().HasData(
                new Driver { driverId = 1, driverFirstName = "Dominik", driverLastName = "Lugmair", license = "B" },
                new Driver { driverId = 2, driverFirstName = "Max", driverLastName = "Sieber", license = "B" },
                new Driver { driverId = 3, driverFirstName = "Karla", driverLastName = "Fuchs", license = "BCD" },
                new Driver { driverId = 4, driverFirstName = "Marlene", driverLastName = "Feuchtinger", license = "BF" }
                );

            modelBuilder.Entity<Location>().HasData(
              new Location { locationId = 1, locationName = "Linz", country = "AUT", postalCode = 4030, street = "Prechtlerstrasse", houseNr = 82 },
               new Location { locationId = 2, locationName = "Linz", country = "AUT", postalCode = 4040, street = "Altenbergerstrasse", houseNr = 69 }

              );

            






        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Trip> Trips { get; set; }

    }


}


