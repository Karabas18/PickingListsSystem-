using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WithoutUserInStatement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_WorkType_WorkTypeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkGroup_AspNetUsers_WorkGroupDirectorId1",
                table: "WorkGroup");

            migrationBuilder.DropIndex(
                name: "IX_WorkGroup_WorkGroupDirectorId1",
                table: "WorkGroup");

            migrationBuilder.DropColumn(
                name: "WorkGroupDirectorId1",
                table: "WorkGroup");

            migrationBuilder.AlterColumn<string>(
                name: "WorkGroupDirectorId",
                table: "WorkGroup",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkGroupDirectorName",
                table: "WorkGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkTypeId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroup_WorkGroupDirectorId",
                table: "WorkGroup",
                column: "WorkGroupDirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_WorkType_WorkTypeId",
                table: "Project",
                column: "WorkTypeId",
                principalTable: "WorkType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkGroup_AspNetUsers_WorkGroupDirectorId",
                table: "WorkGroup",
                column: "WorkGroupDirectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_WorkType_WorkTypeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkGroup_AspNetUsers_WorkGroupDirectorId",
                table: "WorkGroup");

            migrationBuilder.DropIndex(
                name: "IX_WorkGroup_WorkGroupDirectorId",
                table: "WorkGroup");

            migrationBuilder.DropColumn(
                name: "WorkGroupDirectorName",
                table: "WorkGroup");

            migrationBuilder.AlterColumn<int>(
                name: "WorkGroupDirectorId",
                table: "WorkGroup",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkGroupDirectorId1",
                table: "WorkGroup",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkTypeId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroup_WorkGroupDirectorId1",
                table: "WorkGroup",
                column: "WorkGroupDirectorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_WorkType_WorkTypeId",
                table: "Project",
                column: "WorkTypeId",
                principalTable: "WorkType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkGroup_AspNetUsers_WorkGroupDirectorId1",
                table: "WorkGroup",
                column: "WorkGroupDirectorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
