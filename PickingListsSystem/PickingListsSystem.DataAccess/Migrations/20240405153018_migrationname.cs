using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingListsSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migrationname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerContactPercon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolePriority = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfWork = table.Column<int>(type: "int", nullable: true),
                    WorkTypeTranscript = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectObject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_WorkType_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkUnitMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_WorkType_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkType",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "MaterialWork",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialWork", x => new { x.MaterialId, x.WorkId });
                    table.ForeignKey(
                        name: "FK_MaterialWork_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialWork_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorkGroup",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    WorkGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkGroup", x => new { x.ProjectsId, x.WorkGroupId });
                    table.ForeignKey(
                        name: "FK_ProjectWorkGroup_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    WorkGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkGroupStructure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkGroupDirectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkGroup_User_WorkGroupDirectorId",
                        column: x => x.WorkGroupDirectorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialWork_WorkId",
                table: "MaterialWork",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_WorkTypeId",
                table: "Project",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStatement_StatementId",
                table: "ProjectStatement",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkGroup_WorkGroupId",
                table: "ProjectWorkGroup",
                column: "WorkGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_WorkGroupId",
                table: "User",
                column: "WorkGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_WorkTypeId",
                table: "Work",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroup_WorkGroupDirectorId",
                table: "WorkGroup",
                column: "WorkGroupDirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorkGroup_WorkGroup_WorkGroupId",
                table: "ProjectWorkGroup",
                column: "WorkGroupId",
                principalTable: "WorkGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_WorkGroup_WorkGroupId",
                table: "User",
                column: "WorkGroupId",
                principalTable: "WorkGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_WorkGroup_WorkGroupId",
                table: "User");

            migrationBuilder.DropTable(
                name: "MaterialWork");

            migrationBuilder.DropTable(
                name: "ProjectStatement");

            migrationBuilder.DropTable(
                name: "ProjectWorkGroup");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "WorkType");

            migrationBuilder.DropTable(
                name: "WorkGroup");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
