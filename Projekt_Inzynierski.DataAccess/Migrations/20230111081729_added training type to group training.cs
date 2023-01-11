using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektInzynierski.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedtrainingtypetogrouptraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingType",
                table: "GroupTraining",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "GroupTraining");
        }
    }
}
