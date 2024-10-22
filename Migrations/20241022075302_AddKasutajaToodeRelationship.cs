using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BohatyrovAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddKasutajaToodeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kasutajad",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kasutajad",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tooted",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tooted",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tooted",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tooted",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tooted",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.CreateTable(
                name: "KasutajaTooted",
                columns: table => new
                {
                    KasutajaId = table.Column<int>(type: "int", nullable: false),
                    ToodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasutajaTooted", x => new { x.KasutajaId, x.ToodeId });
                    table.ForeignKey(
                        name: "FK_KasutajaTooted_Kasutajad_KasutajaId",
                        column: x => x.KasutajaId,
                        principalTable: "Kasutajad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KasutajaTooted_Tooted_ToodeId",
                        column: x => x.ToodeId,
                        principalTable: "Tooted",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_KasutajaTooted_ToodeId",
                table: "KasutajaTooted",
                column: "ToodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KasutajaTooted");

            migrationBuilder.InsertData(
                table: "Kasutajad",
                columns: new[] { "Id", "Eesnimi", "Kasutajanimi", "Parool", "Perenimi" },
                values: new object[,]
                {
                    { 1, "Oleksandr", "sasa", "123", "Bohatyrov" },
                    { 2, "Artur", "arturi", "123", "Šuškevitš" }
                });

            migrationBuilder.InsertData(
                table: "Tooted",
                columns: new[] { "Id", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "Koola", 1.5 },
                    { 2, false, "Fanta", 1.0 },
                    { 3, true, "Sprite", 1.7 },
                    { 4, true, "Vichy", 2.0 },
                    { 5, true, "Vitamin well", 2.5 }
                });
        }
    }
}
