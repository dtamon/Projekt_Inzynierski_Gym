using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektInzynierski.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedcreatedByfieldtogroupTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "GroupTraining",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupTraining_TrainerId",
                table: "GroupTraining",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTraining_Person_TrainerId",
                table: "GroupTraining",
                column: "TrainerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTraining_Person_TrainerId",
                table: "GroupTraining");

            migrationBuilder.DropIndex(
                name: "IX_GroupTraining_TrainerId",
                table: "GroupTraining");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "GroupTraining");
        }
    }
}
