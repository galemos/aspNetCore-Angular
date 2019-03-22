using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.API.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tema",
                table: "Eventos",
                newName: "Tema");

            migrationBuilder.RenameColumn(
                name: "qtdPessoas",
                table: "Eventos",
                newName: "QtdPessoas");

            migrationBuilder.RenameColumn(
                name: "lote",
                table: "Eventos",
                newName: "Lote");

            migrationBuilder.RenameColumn(
                name: "local",
                table: "Eventos",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "imagemUrl",
                table: "Eventos",
                newName: "ImagemUrl");

            migrationBuilder.RenameColumn(
                name: "dataEvento",
                table: "Eventos",
                newName: "DataEvento");

            migrationBuilder.RenameColumn(
                name: "eventoId",
                table: "Eventos",
                newName: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tema",
                table: "Eventos",
                newName: "tema");

            migrationBuilder.RenameColumn(
                name: "QtdPessoas",
                table: "Eventos",
                newName: "qtdPessoas");

            migrationBuilder.RenameColumn(
                name: "Lote",
                table: "Eventos",
                newName: "lote");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Eventos",
                newName: "local");

            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Eventos",
                newName: "imagemUrl");

            migrationBuilder.RenameColumn(
                name: "DataEvento",
                table: "Eventos",
                newName: "dataEvento");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "Eventos",
                newName: "eventoId");
        }
    }
}
