using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatesupproductmodelentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountEnd",
                table: "SubProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "SubProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountStart",
                table: "SubProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHaveActiveDIscount",
                table: "SubProducts",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountEnd",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "DiscountStart",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "IsHaveActiveDIscount",
                table: "SubProducts");
        }
    }
}
