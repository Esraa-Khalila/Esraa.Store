using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esraa_Store.Migrations
{
    public partial class EsraaSto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exclusives",
                columns: table => new
                {
                    ExclusiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exclusiveImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exclusiveTilte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exclusiveDec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exclusives", x => x.ExclusiveId);
                });

            migrationBuilder.CreateTable(
                name: "featureds",
                columns: table => new
                {
                    FeaturedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    featuredImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    featuredTilte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Like = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_featureds", x => x.FeaturedId);
                });

            migrationBuilder.CreateTable(
                name: "lastestPros",
                columns: table => new
                {
                    LatestProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatestProImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestProTilte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Like = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lastestPros", x => x.LatestProId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exclusives");

            migrationBuilder.DropTable(
                name: "featureds");

            migrationBuilder.DropTable(
                name: "lastestPros");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
