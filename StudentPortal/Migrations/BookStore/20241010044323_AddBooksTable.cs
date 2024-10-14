#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortal.Migrations.BookStore
{
    /// <inheritdoc />
    public partial class AddBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto-incrementing Id
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    CoverImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    // Add foreign key constraints if needed
                    // table.ForeignKey(
                    //     name: "FK_Books_Languages_LanguageId",
                    //     column: x => x.LanguageId,
                    //     principalTable: "Languages",
                    //     principalColumn: "Id",
                    //     onDelete: ReferentialAction.Cascade);
                });

            // If you have relationships with other tables, uncomment and configure the foreign key
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
