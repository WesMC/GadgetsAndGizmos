using Microsoft.EntityFrameworkCore.Migrations;

namespace GadgetsAndGizmos.DataAccessLayer.Migrations
{
    public partial class AddProductTypeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubType = table.Column<string>(maxLength: 65, nullable: false),
                    SubType1 = table.Column<string>(maxLength: 65, nullable: true),
                    SubType2 = table.Column<string>(maxLength: 65, nullable: true),
                    SubType3 = table.Column<string>(maxLength: 65, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
