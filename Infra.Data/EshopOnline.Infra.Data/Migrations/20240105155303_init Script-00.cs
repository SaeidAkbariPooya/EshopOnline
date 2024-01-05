using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopOnline.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initScript00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleFa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceProduct = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PriceDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePriceDiscount = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertiseTitles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiseTitles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AdditiveProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditiveProduct_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propertis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Propertis_PropertiseTitles_TitleID",
                        column: x => x.TitleID,
                        principalTable: "PropertiseTitles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PropertisProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    PropertiseID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertisProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertisProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertisProducts_Propertis_PropertiseID",
                        column: x => x.PropertiseID,
                        principalTable: "Propertis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveProduct_ProductID",
                table: "AdditiveProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Propertis_TitleID",
                table: "Propertis",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertisProducts_ProductID",
                table: "PropertisProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertisProducts_PropertiseID",
                table: "PropertisProducts",
                column: "PropertiseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditiveProduct");

            migrationBuilder.DropTable(
                name: "PropertisProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Propertis");

            migrationBuilder.DropTable(
                name: "PropertiseTitles");
        }
    }
}
