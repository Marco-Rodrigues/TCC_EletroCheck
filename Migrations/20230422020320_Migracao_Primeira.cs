using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EletroCheck.Migrations
{
    /// <inheritdoc />
    public partial class Migracao_Primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    CpfId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.CpfId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    emailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    CpfId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.emailId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Pessoas_CpfId",
                        column: x => x.CpfId,
                        principalTable: "Pessoas",
                        principalColumn: "CpfId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CpfId",
                table: "Usuarios",
                column: "CpfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
