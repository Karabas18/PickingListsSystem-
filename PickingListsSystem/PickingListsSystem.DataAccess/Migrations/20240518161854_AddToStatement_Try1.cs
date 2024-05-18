using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddToStatement_Try1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_WorkType_WorkTypeId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "MaterialStatement");

            migrationBuilder.DropTable(
                name: "StatementWork");

            migrationBuilder.DropIndex(
                name: "IX_Project_WorkTypeId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkTypeId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialStatement",
                columns: table => new
                {
                    MaterialsId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialStatement", x => new { x.MaterialsId, x.StatementId });
                    table.ForeignKey(
                        name: "FK_MaterialStatement_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialStatement_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementWork",
                columns: table => new
                {
                    StatementId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementWork", x => new { x.StatementId, x.WorkId });
                    table.ForeignKey(
                        name: "FK_StatementWork_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatementWork_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_WorkTypeId",
                table: "Project",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialStatement_StatementId",
                table: "MaterialStatement",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementWork_WorkId",
                table: "StatementWork",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_WorkType_WorkTypeId",
                table: "Project",
                column: "WorkTypeId",
                principalTable: "WorkType",
                principalColumn: "Id");
        }
    }
}
