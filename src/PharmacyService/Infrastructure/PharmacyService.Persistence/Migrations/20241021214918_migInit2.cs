using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PharmacyEntities",
                table: "PharmacyEntities");

            migrationBuilder.RenameTable(
                name: "PharmacyEntities",
                newName: "Pharmacy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UK_Pharmacy_Name",
                table: "Pharmacy",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "UK_Pharmacy_Name",
                table: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Pharmacy",
                newName: "PharmacyEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PharmacyEntities",
                table: "PharmacyEntities",
                column: "Id");
        }
    }
}
