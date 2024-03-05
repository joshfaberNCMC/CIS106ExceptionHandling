using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CIS106ExceptionHandling.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Claw hammer for general purpose use", "Hammer", 15.99m },
                    { 2, "Set of Phillips and flat-head screwdrivers", "Screwdriver Set", 9.99m },
                    { 3, "Cordless drill with rechargeable battery", "Drill", 49.99m },
                    { 4, "Set of needle-nose and lineman's pliers", "Pliers", 12.49m },
                    { 5, "25-foot retractable tape measure", "Tape Measure", 7.99m },
                    { 6, "Hand saw for cutting wood and plastic", "Saw", 18.99m },
                    { 7, "Set of paint rollers and tray", "Paint Roller Set", 14.99m },
                    { 8, "Assorted nails for various applications", "Nails Assortment", 5.99m },
                    { 9, "Assorted screws for various applications", "Screws Assortment", 6.99m },
                    { 10, "10-foot extension cord for indoor use", "Extension Cord", 8.99m },
                    { 11, "Retractable utility knife with replaceable blades", "Utility Knife", 4.49m },
                    { 12, "Protective eyewear for use in workshops", "Safety Glasses", 3.99m },
                    { 13, "Pair of heavy-duty work gloves", "Work Gloves", 9.99m },
                    { 14, "Manual caulking gun for applying sealant", "Caulk Gun", 6.49m },
                    { 15, "Set of locks for interior doors", "Door Lock Set", 19.99m },
                    { 16, "Assorted grit sandpaper for sanding surfaces", "Sandpaper Assortment", 3.99m },
                    { 17, "LED flashlight with adjustable focus", "Flashlight", 11.99m },
                    { 18, "Compact cordless screwdriver with magnetic tip", "Cordless Screwdriver", 24.99m },
                    { 19, "Waterproof sealant for sealing gaps and cracks", "Caulk", 5.49m },
                    { 20, "Electronic stud finder for locating studs in walls", "Stud Finder", 14.99m }
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
