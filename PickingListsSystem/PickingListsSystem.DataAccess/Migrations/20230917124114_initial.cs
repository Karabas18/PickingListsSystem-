using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialMark = table.Column<int>(type: "int", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialGost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialRB = table.Column<int>(type: "int", nullable: false),
                    MaterialRL = table.Column<int>(type: "int", nullable: false),
                    MaterialRH = table.Column<int>(type: "int", nullable: false),
                    MaterialV = table.Column<double>(type: "float", nullable: false),
                    MaterialWeight = table.Column<int>(type: "int", nullable: false),
                    MaterialType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
