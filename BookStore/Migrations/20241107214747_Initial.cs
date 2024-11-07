using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CoverImageUrl", "CreatedOn", "IsFeatured", "ModifiedOn", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("a24a6355-8f92-4857-9b69-211319dbcb1e"), "Author 4", "Fiction", "/images/bookcover1.jpg", new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7168), true, new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7169), 5.0, "Book 4" },
                    { new Guid("a885076f-6d95-4b5a-841f-3afdbd082702"), "Author 2", "Fiction", "/images/poster-template-new-scientists.jpg", new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7156), true, new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7157), 200.0, "Book 2" },
                    { new Guid("b12a2281-9db1-4d3d-9dc4-de3881ffdf15"), "Author 5", "Fiction", "/images/online-education-poster-template.jpg", new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7192), true, new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7192), 1409.0, "Book 5" },
                    { new Guid("bde62685-6c17-43d1-bcf1-1af39b2d58fc"), "Author 3", "Tragedy", "/images/pumpkin-drink-poster.jpg", new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7163), true, new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7163), 14.0, "Book 3" },
                    { new Guid("eb6cbf99-ea1f-40dc-bb4a-80bbc595d234"), "Author 1", "Drama", "/images/good-paper-wattpad-book.jpg", new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7108), true, new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7127), 100.98999999999999, "Book 1" },
                    { new Guid("ee95a674-0c4d-4d3b-b676-4e6e25c03732"), "Author 6", "Fiction", "/images/bookcover1.jpg", new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7197), true, new DateTime(2024, 11, 7, 22, 47, 46, 118, DateTimeKind.Local).AddTicks(7198), 5.0, "Book 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
