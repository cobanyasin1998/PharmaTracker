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
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LicenseNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyBranches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PharmacyEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyBranches_Pharmacies_PharmacyEntityId",
                        column: x => x.PharmacyEntityId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyBranchAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    NeighbourhoodId = table.Column<long>(type: "bigint", nullable: true),
                    StreetId = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", nullable: true),
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
                    table.PrimaryKey("PK_PharmacyBranchAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyBranchAddresses_PharmacyBranches_PharmacyBranchEnti~",
                        column: x => x.PharmacyBranchEntityId,
                        principalTable: "PharmacyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyBranchContacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PharmacyBranchEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyBranchContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyBranchContacts_PharmacyBranches_PharmacyBranchEntit~",
                        column: x => x.PharmacyBranchEntityId,
                        principalTable: "PharmacyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_LicenseNumber",
                table: "Pharmacies",
                column: "LicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_Name",
                table: "Pharmacies",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_Status",
                table: "Pharmacies",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchAddresses_PharmacyBranchEntityId",
                table: "PharmacyBranchAddresses",
                column: "PharmacyBranchEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchAddresses_Status",
                table: "PharmacyBranchAddresses",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchContacts_PharmacyBranchEntityId",
                table: "PharmacyBranchContacts",
                column: "PharmacyBranchEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranchContacts_Status",
                table: "PharmacyBranchContacts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranches_BranchName",
                table: "PharmacyBranches",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranches_PharmacyEntityId",
                table: "PharmacyBranches",
                column: "PharmacyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyBranches_Status",
                table: "PharmacyBranches",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyBranchAddresses");

            migrationBuilder.DropTable(
                name: "PharmacyBranchContacts");

            migrationBuilder.DropTable(
                name: "PharmacyBranches");

            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
