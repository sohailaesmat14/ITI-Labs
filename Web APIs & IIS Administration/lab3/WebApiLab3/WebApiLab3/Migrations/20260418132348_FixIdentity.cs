using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLab3.Migrations
{
    /// <inheritdoc />
    public partial class FixIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateIndex(
                name: "IX_Course_Top_Id",
                table: "Course",
                column: "Top_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Dept_Manager",
                table: "Department",
                column: "Dept_Manager");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Course_Crs_Id",
                table: "Ins_Course",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_Dept_Id",
                table: "Instructor",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stud_Course_St_Id",
                table: "Stud_Course",
                column: "St_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Dept_Id",
                table: "Student",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_St_super",
                table: "Student",
                column: "St_super");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor",
                table: "Department",
                column: "Dept_Manager",
                principalTable: "Instructor",
                principalColumn: "Ins_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor",
                table: "Department");

            migrationBuilder.DropTable(
                name: "Ins_Course");

            migrationBuilder.DropTable(
                name: "Stud_Course");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
