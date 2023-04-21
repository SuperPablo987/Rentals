using Microsoft.EntityFrameworkCore;

namespace RentalsData
{
    public class RentalsContext : DbContext
    {
        public RentalsContext() : base() { }

        public DbSet<RentalProperty> RentalProperties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=PropertyRentals;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = 1, Style = "Apartment" },
                new PropertyType { Id = 2, Style = "Townhouse" },
                new PropertyType { Id = 3, Style = "Bungalow" },
                new PropertyType { Id = 4, Style = "Suite" }
                );

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 1,
                    Name = "Ben King",
                    Phone = "403-555-8500"
                },
                new Owner
                {
                    Id = 2,
                    Name = "Paul Wilson",
                    Phone = "403-555-6935"
                },
                new Owner
                {
                    Id = 3,
                    Name = "Kimberly Dunne",
                    Phone = "403-555-4770"
                }
                );

            modelBuilder.Entity<Renter>().HasData(
                new Renter
                {
                    Id = 1,
                    FirstName = "Sam",
                    LastName = "Munro",
                    Phone = "403-555-3456"
                },
                new Renter
                {
                    Id = 2,
                    FirstName = "Sarah",
                    LastName = "Carr",
                    Phone = "403-555-7666"
                },
                new Renter
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Hudon",
                    Phone = "403-555-3000"
                }
                );

            modelBuilder.Entity<RentalProperty>().HasData(
                new RentalProperty
                {
                    Id = 1,
                    Address = "1345 - 670 14th Ave SW",
                    City = "Calgary",
                    Province = "AB",
                    PostalCode = "T3T 3T3",
                    Rent = 1200m,
                    PropertyTypeId = 1,
                    OwnerId = 2,
                    RenterId = 3
                },
                new RentalProperty
                {
                    Id = 2,
                    Address = "4567 66th Ave NW",
                    City = "Calgary",
                    Province = "AB",
                    PostalCode = "T2T 2D2",
                    Rent = 2400m,
                    PropertyTypeId = 3,
                    OwnerId = 1,
                    RenterId = 2
                },
                new RentalProperty
                {
                    Id = 3,
                    Address = "240 - 2111 4th St NW",
                    City = "Calgary",
                    Province = "AB",
                    PostalCode = "T5T 5T5",
                    Rent = 1000m,
                    PropertyTypeId = 4,
                    OwnerId = 3
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "jdoe",
                    Password = "password",
                    FullName = "John Doe",
                    Role = "Manager",
                    OwnerID = null
                },
                new User
                {
                    Id = 2,
                    Username = "khunter",
                    Password = "password",
                    FullName = "Karen Hunter",
                    Role = "Staff",
                    OwnerID = null
                },
                new User
                {
                    Id = 3,
                    Username = "bking",
                    Password = "password",
                    FullName = "Ben King",
                    Role = "Owner",
                    OwnerID = 1
                },new User
                {
                    Id = 4,
                    Username = "pwilson",
                    Password = "password",
                    FullName = "Paul Wilson",
                    Role = "Owner",
                    OwnerID = 2
                },
                new User
                {
                    Id = 5,
                    Username = "kdunne",
                    Password = "password",
                    FullName = "Kimberly Dunne",
                    Role = "Owner",
                    OwnerID = 3
                }
                ); 
        }//OnModelCreating
    }// class
}// namespace
