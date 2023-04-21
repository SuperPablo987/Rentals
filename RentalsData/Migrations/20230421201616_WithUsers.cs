using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalsData.Migrations
{
    public partial class WithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Rent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalProperty_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalProperty_PropertyType_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalProperty_Renter_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Ben King", "403-555-8500" },
                    { 2, "Paul Wilson", "403-555-6935" },
                    { 3, "Kimberly Dunne", "403-555-4770" }
                });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "Id", "Style" },
                values: new object[,]
                {
                    { 1, "Apartment" },
                    { 2, "Townhouse" },
                    { 3, "Bungalow" },
                    { 4, "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Renter",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Sam", "Munro", "403-555-3456" },
                    { 2, "Sarah", "Carr", "403-555-7666" },
                    { 3, "John", "Hudon", "403-555-3000" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "OwnerID", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "John Doe", null, "password", "Manager", "jdoe" },
                    { 2, "Karen Hunter", null, "password", "Staff", "khunter" }
                });

            migrationBuilder.InsertData(
                table: "RentalProperty",
                columns: new[] { "Id", "Address", "City", "OwnerId", "PostalCode", "PropertyTypeId", "Province", "Rent", "RenterId" },
                values: new object[,]
                {
                    { 3, "240 - 2111 4th St NW", "Calgary", 3, "T5T 5T5", 4, "AB", 1000m, null },
                    { 2, "4567 66th Ave NW", "Calgary", 1, "T2T 2D2", 3, "AB", 2400m, 2 },
                    { 1, "1345 - 670 14th Ave SW", "Calgary", 2, "T3T 3T3", 1, "AB", 1200m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "OwnerID", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 3, "Ben King", 1, "password", "Owner", "dking" },
                    { 4, "Paul Wilson", 2, "password", "Owner", "pwilson" },
                    { 5, "Kimberly Dunne", 3, "password", "Owner", "kdunne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_OwnerId",
                table: "RentalProperty",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_PropertyTypeId",
                table: "RentalProperty",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_RenterId",
                table: "RentalProperty",
                column: "RenterId",
                unique: true,
                filter: "[RenterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OwnerID",
                table: "Users",
                column: "OwnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalProperty");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropTable(
                name: "Renter");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
