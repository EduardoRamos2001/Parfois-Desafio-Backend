using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parfois.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    itensAprovados = table.Column<int>(type: "INTEGER", nullable: false),
                    valorAprovado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_pedido = table.Column<int>(type: "INTEGER", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    precoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    qtd = table.Column<int>(type: "INTEGER", nullable: false),
                    Pedidoid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Pedidos_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "Pedidos",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Pedidoid", "descricao", "id_pedido", "precoUnitario", "qtd" },
                values: new object[,]
                {
                    { 1, null, "Item 01", 1, 1.0, 1 },
                    { 2, null, "Item 02", 1, 1.25, 3 },
                    { 3, null, "Item 03", 2, 1.75, 1 },
                    { 4, null, "Item 04", 3, 1.5, 2 },
                    { 5, null, "Item 05", 4, 2.25, 4 }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "id", "itensAprovados", "status", "valorAprovado" },
                values: new object[,]
                {
                    { 1, 0, "Em espera", 0 },
                    { 2, 0, "Em espera", 0 },
                    { 3, 0, "Em espera", 0 },
                    { 4, 0, "Em espera", 0 },
                    { 5, 0, "Em espera", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Pedidoid",
                table: "Items",
                column: "Pedidoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
