using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNewWebProj.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _23234822723d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordValue = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Translate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingsWords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcentLearning = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Stage = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    StagePoint = table.Column<int>(type: "int", nullable: true, defaultValue: 6),
                    StagePointBall = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastTreaning = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Difficult = table.Column<int>(type: "int", nullable: false, defaultValue: 10)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingsWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Id",
                table: "Languages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsWords_Id",
                table: "SettingsWords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsWords_WordId",
                table: "SettingsWords",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_Id",
                table: "Words",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId",
                table: "Words",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingsWords");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
