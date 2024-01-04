using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    public partial class BuildMsDataScanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MsDataScans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanNumber = table.Column<int>(type: "int", nullable: false),
                    SpectrumRepresentation = table.Column<int>(type: "int", nullable: false),
                    MassSpectrumType = table.Column<int>(type: "int", nullable: false),
                    MsLevel = table.Column<int>(type: "int", nullable: false),
                    MassAnalyzerType = table.Column<int>(type: "int", nullable: false),
                    ScanPolarity = table.Column<int>(type: "int", nullable: false),
                    ScanStartTime = table.Column<float>(type: "real", nullable: true),
                    ScanWindowUpperLimit = table.Column<float>(type: "real", nullable: true),
                    ScanWindowLowerLimit = table.Column<float>(type: "real", nullable: true),
                    FilterString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalIonCurrent = table.Column<float>(type: "real", nullable: true),
                    IonInjectionTime = table.Column<float>(type: "real", nullable: true),
                    PrecursorScanNumber = table.Column<int>(type: "int", nullable: true),
                    SelectedIonMz = table.Column<float>(type: "real", nullable: true),
                    ExperimentalPrecursorMonoisotopicMz = table.Column<float>(type: "real", nullable: true),
                    IsolationWindowTargetMz = table.Column<float>(type: "real", nullable: true),
                    IsolationWindowLowerOffset = table.Column<float>(type: "real", nullable: true),
                    IsolationWindowUpperOffset = table.Column<float>(type: "real", nullable: true),
                    DissociationMethod = table.Column<int>(type: "int", nullable: true),
                    NormalizedCollisionEnergy = table.Column<float>(type: "real", nullable: true),
                    SelectedIonChargeStateGuess = table.Column<int>(type: "int", nullable: true),
                    SelectedIonIntensity = table.Column<float>(type: "real", nullable: true),
                    NativeId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsDataScans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MsDataScans");
        }
    }
}
