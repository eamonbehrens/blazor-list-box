using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorListBox.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListBoxItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListBoxItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ListBoxItems",
                columns: new[] { "Id", "DisplayOrder", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Apple" },
                    { 2, 2, "Banana" },
                    { 3, 3, "Cherry" },
                    { 4, 4, "Date" },
                    { 5, 5, "Elderberry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListBoxItems");
        }
    }
}
