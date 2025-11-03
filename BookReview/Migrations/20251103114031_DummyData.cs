using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookReview.Migrations
{
    /// <inheritdoc />
    public partial class DummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "Italo Calvino", "En poetisk samling av berättelser om tänkta städer.", "Fiktion", 1972, "Den osynliga staden" },
                    { 2, "Stieg Larsson", "Första delen i Millennium-serien.", "Thriller", 2005, "Den eviga striden" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "BookId_FK", "CreatedDate", "Rating", "ReviewerName", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Alice Andersson", "Otroligt gripande bok – kunde inte sluta läsa!", null },
                    { 2, null, 2, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Björn Berg", "Riktigt spännande, men lite förutsägbar på slutet.", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Vicke Andersson", "hash123", "Admin" },
                    { 2, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bjorn@example.com", "Björn Berg", "hash456", "User" },
                    { 3, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "clara@example.com", "Anders Hertig", "hash789", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
