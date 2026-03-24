using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPresupuestosSockets.Migrations
{
    /// <inheritdoc />
    public partial class AgregoDescPresupuesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Presupuestos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Presupuestos");
        }
    }
}
