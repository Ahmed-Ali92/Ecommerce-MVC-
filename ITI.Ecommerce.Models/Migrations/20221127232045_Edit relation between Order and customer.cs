using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Ecommerce.Models.Migrations
{
    public partial class EditrelationbetweenOrderandcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    customersListID = table.Column<int>(type: "int", nullable: false),
                    orderListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => new { x.customersListID, x.orderListID });
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Customer_customersListID",
                        column: x => x.customersListID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Order_orderListID",
                        column: x => x.orderListID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_orderListID",
                table: "CustomerOrder",
                column: "orderListID");
        }
    }
}
