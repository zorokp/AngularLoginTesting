using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiService.Migrations
{
    public partial class Added_Supplier_Address_To_Supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Address_AddressId",
                table: "Supplier",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Address_AddressId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier");
        }
    }
}
