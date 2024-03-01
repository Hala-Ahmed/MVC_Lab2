using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGRSSN = table.Column<int>(type: "int", nullable: true),
                    MGRStartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dno);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Superssn = table.Column<int>(type: "int", nullable: true),
                    Dno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Dno",
                        column: x => x.Dno,
                        principalTable: "Departments",
                        principalColumn: "Dno");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_Superssn",
                        column: x => x.Superssn,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Pnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Pnumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_Dno",
                        column: x => x.Dno,
                        principalTable: "Departments",
                        principalColumn: "Dno");
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESSN = table.Column<int>(type: "int", nullable: true),
                    DependentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Bdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "WorksFor",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pno = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksFor", x => new { x.ESSN, x.Pno });
                    table.ForeignKey(
                        name: "FK_WorksFor_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksFor_Projects_Pno",
                        column: x => x.Pno,
                        principalTable: "Projects",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MGRSSN",
                table: "Departments",
                column: "MGRSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_ESSN",
                table: "Dependents",
                column: "ESSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dno",
                table: "Employees",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Superssn",
                table: "Employees",
                column: "Superssn");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Dno",
                table: "Projects",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_Pno",
                table: "WorksFor",
                column: "Pno");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_MGRSSN",
                table: "Departments",
                column: "MGRSSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_MGRSSN",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "WorksFor");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
