using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class AddedResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdminId = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Semester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Semester = table.Column<int>(nullable: false),
                    Course1 = table.Column<string>(nullable: true),
                    Course2 = table.Column<string>(nullable: true),
                    Course3 = table.Column<string>(nullable: true),
                    Course4 = table.Column<string>(nullable: true),
                    Course5 = table.Column<string>(nullable: true),
                    Course6 = table.Column<string>(nullable: true),
                    Marks1 = table.Column<int>(nullable: false),
                    Marks2 = table.Column<int>(nullable: false),
                    Marks3 = table.Column<int>(nullable: false),
                    Marks4 = table.Column<int>(nullable: false),
                    Marks5 = table.Column<int>(nullable: false),
                    Marks6 = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
