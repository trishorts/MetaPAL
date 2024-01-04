using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    public partial class InitializeExperimentMetaDataAndDataFileModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "DataFileId",
                table: "MsDataScans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepositoryIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.Id);
                });

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
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFileId = table.Column<int>(type: "int", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DataFiles");

            migrationBuilder.DropTable(
                name: "Experiments");

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
                name: "DataFileId",
                table: "MsDataScans");
        }
    }
}
