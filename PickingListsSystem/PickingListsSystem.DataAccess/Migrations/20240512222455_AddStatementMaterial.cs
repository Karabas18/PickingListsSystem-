using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStatementMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Statement_StatementId",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "ProjectStatement");

            migrationBuilder.DropIndex(
                name: "IX_Materials_StatementId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "StatementId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Statement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatementMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementMaterial", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statement_ProjectId",
                table: "Statement",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_Project_ProjectId",
                table: "Statement",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statement_Project_ProjectId",
                table: "Statement");

            migrationBuilder.DropTable(
                name: "StatementMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Statement_ProjectId",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Statement");

            migrationBuilder.AddColumn<int>(
                name: "StatementId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectStatement",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatement", x => new { x.ProjectId, x.StatementId });
                    table.ForeignKey(
                        name: "FK_ProjectStatement_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectStatement_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_StatementId",
                table: "Materials",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStatement_StatementId",
                table: "ProjectStatement",
                column: "StatementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Statement_StatementId",
                table: "Materials",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id");
        }
    }
}
