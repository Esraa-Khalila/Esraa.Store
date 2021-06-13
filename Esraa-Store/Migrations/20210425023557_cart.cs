using Microsoft.EntityFrameworkCore.Migrations;

namespace Esraa_Store.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Que = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    FeaturedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_carts_featureds_FeaturedId",
                        column: x => x.FeaturedId,
                        principalTable: "featureds",
                        principalColumn: "FeaturedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_FeaturedId",
                table: "carts",
                column: "FeaturedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts");
        }
    }
}
