using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EletroCheck.Migrations
{
    /// <inheritdoc />
    public partial class CriarNovasClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CadastroContaConsumo",
                columns: table => new
                {
                    IdentificadorContaConsumo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    UrlIframePowerBI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroContaConsumo", x => x.IdentificadorContaConsumo);
                });

            

            migrationBuilder.CreateTable(
                name: "UserPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdentificadorContaConsumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CadastroContaConsumoIdentificadorContaConsumo = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPost_AspNetUsers_UserNameId",
                        column: x => x.UserNameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPost_CadastroContaConsumo_CadastroContaConsumoIdentificadorContaConsumo",
                        column: x => x.CadastroContaConsumoIdentificadorContaConsumo,
                        principalTable: "CadastroContaConsumo",
                        principalColumn: "IdentificadorContaConsumo");
                });

           


            migrationBuilder.CreateIndex(
                name: "IX_UserPost_CadastroContaConsumoIdentificadorContaConsumo",
                table: "UserPost",
                column: "CadastroContaConsumoIdentificadorContaConsumo");

            migrationBuilder.CreateIndex(
                name: "IX_UserPost_UserNameId",
                table: "UserPost",
                column: "UserNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "UserPost");

          
            migrationBuilder.DropTable(
                name: "CadastroContaConsumo");
        }
    }
}
