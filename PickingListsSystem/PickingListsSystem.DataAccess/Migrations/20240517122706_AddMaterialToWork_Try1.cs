using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialToWork_Try1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWork_Materials_MaterialId",
                table: "MaterialWork");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "MaterialWork",
                newName: "MaterialsId");

            migrationBuilder.CreateTable(
                name: "ProjectWork",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWork", x => new { x.ProjectId, x.WorkId });
                    table.ForeignKey(
                        name: "FK_ProjectWork_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWork_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWork_WorkId",
                table: "ProjectWork",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWork_Materials_MaterialsId",
                table: "MaterialWork",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWork_Materials_MaterialsId",
                table: "MaterialWork");

            migrationBuilder.DropTable(
                name: "ProjectWork");

            migrationBuilder.RenameColumn(
                name: "MaterialsId",
                table: "MaterialWork",
                newName: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWork_Materials_MaterialId",
                table: "MaterialWork",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
