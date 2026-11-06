using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLab.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cages_Strains_StrainId",
                        column: x => x.StrainId,
                        principalTable: "Strains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    StrainId = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: false),
                    FatherId = table.Column<int>(type: "int", nullable: true),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Animals_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_Animals_MotherId",
                        column: x => x.MotherId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Strains_StrainId",
                        column: x => x.StrainId,
                        principalTable: "Strains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaleId = table.Column<int>(type: "int", nullable: false),
                    FemaleId = table.Column<int>(type: "int", nullable: false),
                    BreedingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultStatus = table.Column<int>(type: "int", nullable: false),
                    OffspringCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedingRecords_Animals_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedingRecords_Animals_MaleId",
                        column: x => x.MaleId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InbreedingAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaleId = table.Column<int>(type: "int", nullable: false),
                    FemaleId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Methodology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskFlag = table.Column<bool>(type: "bit", nullable: false),
                    AnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InbreedingAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InbreedingAnalyses_Animals_FemaleId",
                        column: x => x.FemaleId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InbreedingAnalyses_Animals_MaleId",
                        column: x => x.MaleId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vaccination = table.Column<bool>(type: "bit", nullable: false),
                    HealthObservations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Strains",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[] { 1, new DateTime(2026, 11, 6, 19, 4, 25, 623, DateTimeKind.Utc).AddTicks(8933), "Wild Type", "WT" });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Name", "StrainId" },
                values: new object[] { 1, "Cage A", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CageId",
                table: "Animals",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_FatherId",
                table: "Animals",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_MotherId",
                table: "Animals",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_StrainId",
                table: "Animals",
                column: "StrainId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_FemaleId",
                table: "BreedingRecords",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_MaleId",
                table: "BreedingRecords",
                column: "MaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cages_StrainId",
                table: "Cages",
                column: "StrainId");

            migrationBuilder.CreateIndex(
                name: "IX_InbreedingAnalyses_FemaleId",
                table: "InbreedingAnalyses",
                column: "FemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_InbreedingAnalyses_MaleId",
                table: "InbreedingAnalyses",
                column: "MaleId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AnimalId",
                table: "MedicalRecords",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedingRecords");

            migrationBuilder.DropTable(
                name: "InbreedingAnalyses");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Strains");
        }
    }
}
