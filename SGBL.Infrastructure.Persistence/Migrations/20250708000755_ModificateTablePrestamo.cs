using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGBL.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModificateTablePrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_User_UsuarioId",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Prestamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_User_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_User_UsuarioId",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_User_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
