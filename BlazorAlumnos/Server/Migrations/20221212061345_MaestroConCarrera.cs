using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAlumnos.Server.Migrations
{
    public partial class MaestroConCarrera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "Maestros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_CarreraId",
                table: "Maestros",
                column: "CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maestros_Carreras_CarreraId",
                table: "Maestros",
                column: "CarreraId",
                principalTable: "Carreras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maestros_Carreras_CarreraId",
                table: "Maestros");

            migrationBuilder.DropIndex(
                name: "IX_Maestros_CarreraId",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "Maestros");
        }
    }
}
