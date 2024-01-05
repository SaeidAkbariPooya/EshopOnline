using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopOnline.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initScript02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePriceDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                table: "Products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PriceProduct",
                table: "Products",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "TitleFa");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PriceProduct");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePriceDiscount",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PriceDiscount",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
