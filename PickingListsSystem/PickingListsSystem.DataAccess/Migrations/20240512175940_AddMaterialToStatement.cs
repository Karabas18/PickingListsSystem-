using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialToStatement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatementId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_StatementId",
                table: "Materials",
                column: "StatementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Statement_StatementId",
                table: "Materials",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Statement_StatementId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_StatementId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "StatementId",
                table: "Materials");
        }
    }
}
