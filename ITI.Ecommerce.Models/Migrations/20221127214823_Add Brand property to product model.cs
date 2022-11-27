using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Ecommerce.Models.Migrations
{
    public partial class AddBrandpropertytoproductmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");
        }
    }
}
