using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiService.Migrations
{
    public partial class Added_AddressType_Field_to_Supplier_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressType",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Address");
        }
    }
}
