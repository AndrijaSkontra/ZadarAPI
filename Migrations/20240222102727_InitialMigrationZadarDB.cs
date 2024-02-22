using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadarAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationZadarDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kvarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeQuality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kvarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfHomes = table.Column<int>(type: "int", nullable: false),
                    Lenght = table.Column<float>(type: "real", nullable: false),
                    KvartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_Kvarts_KvartId",
                        column: x => x.KvartId,
                        principalTable: "Kvarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Streets_KvartId",
                table: "Streets",
                column: "KvartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Kvarts");
        }
    }
}
