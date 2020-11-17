using Microsoft.EntityFrameworkCore.Migrations;

namespace GadgetsAndGizmos.DataAccessLayer.Migrations
{
    public partial class addProductToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    MSRP = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Distributor = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    VolumeX = table.Column<double>(nullable: false),
                    VolumeY = table.Column<double>(nullable: false),
                    VolumeZ = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
