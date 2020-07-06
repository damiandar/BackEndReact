using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndReact.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automotor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(nullable: false),
                    KMS = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automotor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automotor");

            migrationBuilder.DropTable(
                name: "Comentario");
        }
    }
}
