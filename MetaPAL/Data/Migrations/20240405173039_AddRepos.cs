using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    public partial class AddRepos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpectrumMatch_DataFiles_DataFileId",
                table: "SpectrumMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_SpectrumMatch_Experiments_ExperimentId",
                table: "SpectrumMatch");

            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.DropTable(
                name: "MsDataScans");

            migrationBuilder.DropTable(
                name: "DataFiles");

            migrationBuilder.DropIndex(
                name: "IX_SpectrumMatch_DataFileId",
                table: "SpectrumMatch");

            migrationBuilder.DropIndex(
                name: "IX_SpectrumMatch_ExperimentId",
                table: "SpectrumMatch");

            migrationBuilder.DropColumn(
                name: "DataFileId",
                table: "SpectrumMatch");

            migrationBuilder.DropColumn(
                name: "ExperimentId",
                table: "SpectrumMatch");

            migrationBuilder.DropColumn(
                name: "RepositoryIdentifier",
                table: "Experiments");

            migrationBuilder.AddColumn<int>(
                name: "ExperimentMetaDataId",
                table: "Experiments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExperimentMetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentMetaData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProteomicsQuantificationResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteomicsQuantificationResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProteomicsQuantificationResult_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProteomicsSearchResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteomicsSearchResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProteomicsSearchResult_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Repo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostingRepositoryURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatasetFtpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleMetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BiologicalReplicate = table.Column<int>(type: "int", nullable: true),
                    TechnicalReplicate = table.Column<int>(type: "int", nullable: true),
                    Fraction = table.Column<int>(type: "int", nullable: true),
                    PsmFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamplePreparationBatch = table.Column<int>(type: "int", nullable: true),
                    LcBatchNumber = table.Column<int>(type: "int", nullable: true),
                    Instrument = table.Column<int>(type: "int", nullable: true),
                    Quantification = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleMetaData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_ExperimentMetaDataId",
                table: "Experiments",
                column: "ExperimentMetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteomicsQuantificationResult_ExperimentId",
                table: "ProteomicsQuantificationResult",
                column: "ExperimentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteomicsSearchResult_ExperimentId",
                table: "ProteomicsSearchResult",
                column: "ExperimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiments_ExperimentMetaData_ExperimentMetaDataId",
                table: "Experiments",
                column: "ExperimentMetaDataId",
                principalTable: "ExperimentMetaData",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiments_ExperimentMetaData_ExperimentMetaDataId",
                table: "Experiments");

            migrationBuilder.DropTable(
                name: "ExperimentMetaData");

            migrationBuilder.DropTable(
                name: "ProteomicsQuantificationResult");

            migrationBuilder.DropTable(
                name: "ProteomicsSearchResult");

            migrationBuilder.DropTable(
                name: "Repo");

            migrationBuilder.DropTable(
                name: "SampleMetaData");

            migrationBuilder.DropIndex(
                name: "IX_Experiments_ExperimentMetaDataId",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "ExperimentMetaDataId",
                table: "Experiments");

            migrationBuilder.AddColumn<int>(
                name: "DataFileId",
                table: "SpectrumMatch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperimentId",
                table: "SpectrumMatch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepositoryIdentifier",
                table: "Experiments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentId = table.Column<int>(type: "int", nullable: false),
                    FileNameWithoutExtension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataFiles_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MsDataScans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFileId = table.Column<int>(type: "int", nullable: false),
                    DissociationMethod = table.Column<int>(type: "int", nullable: true),
                    ExperimentalPrecursorMonoisotopicMz = table.Column<float>(type: "real", nullable: true),
                    FilterString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IonInjectionTime = table.Column<float>(type: "real", nullable: true),
                    IsolationWindowLowerOffset = table.Column<float>(type: "real", nullable: true),
                    IsolationWindowTargetMz = table.Column<float>(type: "real", nullable: true),
                    IsolationWindowUpperOffset = table.Column<float>(type: "real", nullable: true),
                    MassAnalyzerType = table.Column<int>(type: "int", nullable: false),
                    MassSpectrumType = table.Column<int>(type: "int", nullable: false),
                    MsLevel = table.Column<int>(type: "int", nullable: false),
                    NativeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedCollisionEnergy = table.Column<float>(type: "real", nullable: true),
                    PrecursorScanNumber = table.Column<int>(type: "int", nullable: true),
                    ScanNumber = table.Column<int>(type: "int", nullable: false),
                    ScanPolarity = table.Column<int>(type: "int", nullable: false),
                    ScanStartTime = table.Column<float>(type: "real", nullable: true),
                    ScanWindowLowerLimit = table.Column<float>(type: "real", nullable: true),
                    ScanWindowUpperLimit = table.Column<float>(type: "real", nullable: true),
                    SelectedIonChargeStateGuess = table.Column<int>(type: "int", nullable: true),
                    SelectedIonIntensity = table.Column<float>(type: "real", nullable: true),
                    SelectedIonMz = table.Column<float>(type: "real", nullable: true),
                    SpectrumRepresentation = table.Column<int>(type: "int", nullable: false),
                    TotalIonCurrent = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsDataScans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFileId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaData_DataFiles_DataFileId",
                        column: x => x.DataFileId,
                        principalTable: "DataFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumMatch_DataFileId",
                table: "SpectrumMatch",
                column: "DataFileId");

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumMatch_ExperimentId",
                table: "SpectrumMatch",
                column: "ExperimentId");

            migrationBuilder.CreateIndex(
                name: "IX_DataFiles_ExperimentId",
                table: "DataFiles",
                column: "ExperimentId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_DataFileId",
                table: "MetaData",
                column: "DataFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpectrumMatch_DataFiles_DataFileId",
                table: "SpectrumMatch",
                column: "DataFileId",
                principalTable: "DataFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpectrumMatch_Experiments_ExperimentId",
                table: "SpectrumMatch",
                column: "ExperimentId",
                principalTable: "Experiments",
                principalColumn: "Id");
        }
    }
}
