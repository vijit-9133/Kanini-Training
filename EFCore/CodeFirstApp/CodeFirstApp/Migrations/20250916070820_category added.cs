using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApp.Migrations
{
    /// <inheritdoc />
    public partial class categoryadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryCId",
                table: "Products",
                type: "int",
                nullable: true
                );

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCId",
                table: "Products",
                column: "CategoryCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCId",
                table: "Products",
                column: "CategoryCId",
                principalTable: "Categories",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCId",
                table: "Products");
        }
    }
}
