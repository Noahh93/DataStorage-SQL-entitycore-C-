using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorage.Migrations
{
    /// <inheritdoc />
    public partial class ErrorReportStatusNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorReports_Status_StatusID",
                table: "ErrorReports");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "ErrorReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorReports_Status_StatusID",
                table: "ErrorReports",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorReports_Status_StatusID",
                table: "ErrorReports");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "ErrorReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorReports_Status_StatusID",
                table: "ErrorReports",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
