using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSV.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_SV_StudentId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_StudentId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Logs",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "LogId",
                table: "Logs",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Logs",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Logs",
                newName: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_StudentId",
                table: "Logs",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_SV_StudentId",
                table: "Logs",
                column: "StudentId",
                principalTable: "SV",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
