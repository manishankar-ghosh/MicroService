using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admission.Migrations
{
    /// <inheritdoc />
    public partial class updateTableDef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Corse",
                table: "tb_Admission",
                newName: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Course",
                table: "tb_Admission",
                newName: "Corse");
        }
    }
}
