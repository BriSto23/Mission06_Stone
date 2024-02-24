using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieApp_Title_TitleId",
                table: "MovieApp");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropIndex(
                name: "IX_MovieApp_TitleId",
                table: "MovieApp");

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "MovieApp",
                newName: "Year");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "MovieApp",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Edited",
                table: "MovieApp",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MovieApp",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CopiedToPlex",
                table: "MovieApp",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "MovieApp",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MovieApp",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Miscellaneous" },
                    { 2, "Drama" },
                    { 3, "Television" },
                    { 4, "Horror/Suspense" },
                    { 5, "Comedy" },
                    { 6, "Family" },
                    { 7, "Action/Adventure" },
                    { 8, "VHS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieApp_CategoryId",
                table: "MovieApp",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieApp_Category_CategoryId",
                table: "MovieApp",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieApp_Category_CategoryId",
                table: "MovieApp");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_MovieApp_CategoryId",
                table: "MovieApp");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MovieApp");

            migrationBuilder.DropColumn(
                name: "CopiedToPlex",
                table: "MovieApp");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "MovieApp");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MovieApp");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "MovieApp",
                newName: "TitleId");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "MovieApp",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Edited",
                table: "MovieApp",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "TitleName" },
                values: new object[,]
                {
                    { 1, "Harry Potter" },
                    { 2, "Lord of the Rings" },
                    { 3, "Avatar" },
                    { 4, "Star Wars" },
                    { 5, "Percy Jackson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieApp_TitleId",
                table: "MovieApp",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieApp_Title_TitleId",
                table: "MovieApp",
                column: "TitleId",
                principalTable: "Title",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
