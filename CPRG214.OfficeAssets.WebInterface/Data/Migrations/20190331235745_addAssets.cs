using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.OfficeAssets.WebInterface.Data.Migrations
{
    public partial class addAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagNumber = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ProductTypeId",
                table: "Assets",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
