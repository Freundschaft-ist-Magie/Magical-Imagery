using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class LicensesTableToUpperCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_licences_LicenceId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_licences",
                table: "licences");

            migrationBuilder.RenameTable(
                name: "licences",
                newName: "Licences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licences",
                table: "Licences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Licences_LicenceId",
                table: "Products",
                column: "LicenceId",
                principalTable: "Licences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Licences_LicenceId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licences",
                table: "Licences");

            migrationBuilder.RenameTable(
                name: "Licences",
                newName: "licences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_licences",
                table: "licences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_licences_LicenceId",
                table: "Products",
                column: "LicenceId",
                principalTable: "licences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
