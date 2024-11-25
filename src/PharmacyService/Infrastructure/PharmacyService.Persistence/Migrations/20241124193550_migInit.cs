using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmacyService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PharmacyEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyBranchEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchName = table.Column<string>(type: "text", nullable: false),
                    PharmacyEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyBranchEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyBranchEntities_PharmacyEntities_PharmacyEntityId",
                        column: x => x.PharmacyEntityId,
                        principalTable: "PharmacyEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyBranchAddressEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    NeighbourhoodId = table.Column<long>(type: "bigint", nullable: true),
                    StreetId = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: true),
                    PharmacyBranchEntityBranchId = table.Column<long>(type: "bigint", nullable: false),
                    PharmacyBranchEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyBranchAddressEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyBranchAddressEntities_PharmacyBranchEntities_Pharma~",
                        column: x => x.PharmacyBranchEntityId,
                        principalTable: "PharmacyBranchEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyBranchContactEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactType = table.Column<byte>(type: "smallint", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    PharmacyBranchEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyBranchContactEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyBranchContactEntities_PharmacyBranchEntities_Pharma~",
                        column: x => x.PharmacyBranchEntityId,
                        principalTable: "PharmacyBranchEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchAddressEntities_PharmacyBranchEntityId",
                table: "PharmacyBranchAddressEntities",
                column: "PharmacyBranchEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchContactEntities_PharmacyBranchEntityId",
                table: "PharmacyBranchContactEntities",
                column: "PharmacyBranchEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchEntities_PharmacyEntityId",
                table: "PharmacyBranchEntities",
                column: "PharmacyEntityId");

            migrationBuilder.CreateIndex(
                name: "UK_Pharmacy_Name",
                table: "PharmacyEntities",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyBranchAddressEntities");

            migrationBuilder.DropTable(
                name: "PharmacyBranchContactEntities");

            migrationBuilder.DropTable(
                name: "PharmacyBranchEntities");

            migrationBuilder.DropTable(
                name: "PharmacyEntities");
        }
    }
}
