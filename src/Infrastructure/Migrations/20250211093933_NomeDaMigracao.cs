using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logradouro_Clientes_ClienteId",
                table: "Logradouro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logradouro",
                table: "Logradouro");

            migrationBuilder.RenameTable(
                name: "Logradouro",
                newName: "Logradouros");

            migrationBuilder.RenameIndex(
                name: "IX_Logradouro_ClienteId",
                table: "Logradouros",
                newName: "IX_Logradouros_ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logradouros",
                table: "Logradouros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logradouros_Clientes_ClienteId",
                table: "Logradouros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logradouros_Clientes_ClienteId",
                table: "Logradouros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logradouros",
                table: "Logradouros");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Logradouros",
                newName: "Logradouro");

            migrationBuilder.RenameIndex(
                name: "IX_Logradouros_ClienteId",
                table: "Logradouro",
                newName: "IX_Logradouro_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logradouro",
                table: "Logradouro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logradouro_Clientes_ClienteId",
                table: "Logradouro",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
