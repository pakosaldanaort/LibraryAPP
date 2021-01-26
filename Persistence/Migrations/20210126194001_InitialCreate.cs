using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    IsLibrerian = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    ISBN = table.Column<string>(type: "TEXT", nullable: true),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OverDueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CheckOutDate", "ISBN", "OverDueDate", "Title", "UserId" },
                values: new object[] { 1, "Book 1 Author", null, "123456789", null, "Book 1", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CheckOutDate", "ISBN", "OverDueDate", "Title", "UserId" },
                values: new object[] { 2, "Book 2 Author", null, "987654321", null, "Book 2", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CheckOutDate", "ISBN", "OverDueDate", "Title", "UserId" },
                values: new object[] { 3, "Book 3 Author", null, "345692817", null, "Book 3", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CheckOutDate", "ISBN", "OverDueDate", "Title", "UserId" },
                values: new object[] { 4, "Book 4 Author", null, "248728749", null, "Book 4", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "IsLibrerian", "LastName", "Password" },
                values: new object[] { 1, "user1@gmail.com", "User 1", true, "Librarian", "12345" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "IsLibrerian", "LastName", "Password" },
                values: new object[] { 2, "user2@gmail.com", "User 2", false, "NormalUser", "12345" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "IsLibrerian", "LastName", "Password" },
                values: new object[] { 3, "user3@gmail.com", "User 3", false, "NormalUser", "12345" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "IsLibrerian", "LastName", "Password" },
                values: new object[] { 4, "user4@gmail.com", "User 4", false, "NormalUser", "12345" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
