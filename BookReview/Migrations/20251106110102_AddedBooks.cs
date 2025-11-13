using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookReview.Migrations
{
    /// <inheritdoc />
    public partial class AddedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 3, "Imre Kertész", "En stark berättelse om en ung pojkes upplevelser under Förintelsen.", "Historisk roman", 1975, "Mannen utan öde" },
                    { 4, "Jane Austen", "En tidlös berättelse om kärlek, stolthet och samhällsnormer i 1800-talets England.", "Klassiker", 1813, "Stolthet och fördom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
