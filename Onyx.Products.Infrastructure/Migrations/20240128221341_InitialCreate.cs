using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Onyx.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Colour = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Colour", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"), 1, 2, "Cotton T-shirt for casual wear", "T-shirt", 19.99m },
                    { new Guid("1ffe7a31-8dcc-4ff0-9b2d-5f148e2989cc"), 11, 1, "Daily multivitamin tablets for adults", "Multivitamin Tablets", 24.99m },
                    { new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), 0, 8, "High-end smartphone with advanced features", "Smartphone", 599.99m },
                    { new Guid("2ffe7a31-8dcc-4ff0-9b2d-5f148e2989cd"), 8, 2, "3-seater sofa with fabric upholstery", "Sofa", 499.99m },
                    { new Guid("3ffe7a31-8dcc-4ff0-9b2d-5f148e2989ce"), 12, 0, "Fresh, juicy apples", "Apples", 2.49m },
                    { new Guid("4ffe7a31-8dcc-4ff0-9b2d-5f148e2989cf"), 4, 2, "Adjustable dog collar for medium-sized dogs", "Dog Collar", 14.99m },
                    { new Guid("56e40388-6f31-4548-904b-cc4ba8d0bc8e"), 13, 8, "A5 size ruled notebook", "Notebook", 4.99m },
                    { new Guid("aefe7a31-8dcc-4ff0-9b2d-5f148e2989c6"), 9, 1, "Programmable coffee maker for home use", "Coffee Maker", 49.99m },
                    { new Guid("befe7a31-8dcc-4ff0-9b2d-5f148e2989c7"), 3, 0, "Matte lipstick in bold red shade", "Lipstick", 9.99m },
                    { new Guid("cefe7a31-8dcc-4ff0-9b2d-5f148e2989c8"), 4, 9, "First book in the Harry Potter series", "Harry Potter and the Philosopher's Stone", 12.99m },
                    { new Guid("defe7a31-8dcc-4ff0-9b2d-5f148e2989c9"), 5, 10, "Buildable LEGO model of the Millennium Falcon", "LEGO Star Wars Millennium Falcon", 149.99m },
                    { new Guid("eefe7a31-8dcc-4ff0-9b2d-5f148e2989ca"), 6, 8, "Official size and weight football", "Football", 29.99m },
                    { new Guid("fefe7a31-8dcc-4ff0-9b2d-5f148e2989cb"), 10, 2, "Portable vacuum cleaner for cars", "Car Vacuum Cleaner", 39.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
