using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpectrumMatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchedFragmentIons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullSequence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ms2ScanNumber = table.Column<int>(type: "int", nullable: false),
                    FileNameWithoutExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecursorScanNum = table.Column<int>(type: "int", nullable: false),
                    PrecursorCharge = table.Column<int>(type: "int", nullable: false),
                    PrecursorMz = table.Column<double>(type: "float", nullable: false),
                    PrecursorMass = table.Column<double>(type: "float", nullable: false),
                    RetentionTime = table.Column<double>(type: "float", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false),
                    SpectrumMatchCount = table.Column<int>(type: "int", nullable: false),
                    Accession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpectralAngle = table.Column<double>(type: "float", nullable: true),
                    QValue = table.Column<double>(type: "float", nullable: false),
                    PEP = table.Column<double>(type: "float", nullable: false),
                    PEP_QValue = table.Column<double>(type: "float", nullable: false),
                    TotalIonCurrent = table.Column<double>(type: "float", nullable: true),
                    DeltaScore = table.Column<double>(type: "float", nullable: true),
                    Notch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseSeq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EssentialSeq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmbiguityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissedCleavage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonoisotopicMass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MassDiffDa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MassDiffPpm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganismName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntersectingSequenceVariations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifiedSequenceVariations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpliceSites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAndEndResiduesInParentSequence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousResidue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextResidue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecoyContamTarget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QValueNotch = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpectrumMatch", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpectrumMatch");
        }
    }
}
