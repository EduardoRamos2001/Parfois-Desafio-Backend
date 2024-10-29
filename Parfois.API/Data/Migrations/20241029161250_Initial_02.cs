using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfois.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Pedidos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "pedido",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "id",
                keyValue: 1,
                column: "pedido",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "id",
                keyValue: 2,
                column: "pedido",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "id",
                keyValue: 3,
                column: "pedido",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "id",
                keyValue: 4,
                column: "pedido",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "id",
                keyValue: 5,
                column: "pedido",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pedido",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
