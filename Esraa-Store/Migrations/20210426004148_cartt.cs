using Microsoft.EntityFrameworkCore.Migrations;

namespace Esraa_Store.Migrations
{
    public partial class cartt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "featureds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "que",
                table: "featureds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "featureds");

            migrationBuilder.DropColumn(
                name: "que",
                table: "featureds");

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeaturedId = table.Column<int>(type: "int", nullable: false),
                    Que = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
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
    }
}
