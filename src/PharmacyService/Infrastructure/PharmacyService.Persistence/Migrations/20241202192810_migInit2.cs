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
            migrationBuilder.DropColumn(
                name: "PharmacyBranchEntityBranchId",
                table: "PharmacyBranchAddresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PharmacyBranchEntityBranchId",
                table: "PharmacyBranchAddresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
