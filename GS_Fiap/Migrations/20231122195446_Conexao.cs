using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GS_Fiap.Migrations
{
    public partial class Conexao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_EfeitoColateral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Efeito = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EfeitoColateral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Consulta",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Consulta", x => new { x.PacienteId, x.MedicoId });
                    table.ForeignKey(
                        name: "FK_Tbl_Consulta_Tbl_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Tbl_Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Consulta_Tbl_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Tbl_Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    Dosagem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Frequencia = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    EfeitoColateralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Medicamento_Tbl_EfeitoColateral_EfeitoColateralId",
                        column: x => x.EfeitoColateralId,
                        principalTable: "Tbl_EfeitoColateral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Medicamento_Tbl_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Tbl_Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Consulta_MedicoId",
                table: "Tbl_Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Medicamento_EfeitoColateralId",
                table: "Tbl_Medicamento",
                column: "EfeitoColateralId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Medicamento_PacienteId",
                table: "Tbl_Medicamento",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Consulta");

            migrationBuilder.DropTable(
                name: "Tbl_Medicamento");

            migrationBuilder.DropTable(
                name: "Tbl_Medico");

            migrationBuilder.DropTable(
                name: "Tbl_EfeitoColateral");

            migrationBuilder.DropTable(
                name: "Tbl_Paciente");
        }
    }
}
