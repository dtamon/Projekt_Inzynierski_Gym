using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektInzynierski.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Months = table.Column<int>(type: "int", nullable: false),
                    MonthlyCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTraining",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxCLients = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTraining", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    ContractStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployedFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployedTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGroupTraining",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    GroupTrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGroupTraining", x => new { x.ClientsId, x.GroupTrainingsId });
                    table.ForeignKey(
                        name: "FK_ClientGroupTraining_GroupTraining_GroupTrainingsId",
                        column: x => x.GroupTrainingsId,
                        principalTable: "GroupTraining",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientGroupTraining_Person_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainingTrainer",
                columns: table => new
                {
                    GroupTrainingsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainingTrainer", x => new { x.GroupTrainingsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_GroupTrainingTrainer_GroupTraining_GroupTrainingsId",
                        column: x => x.GroupTrainingsId,
                        principalTable: "GroupTraining",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTrainingTrainer_Person_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationTrainer",
                columns: table => new
                {
                    SpecializationsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationTrainer", x => new { x.SpecializationsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_SpecializationTrainer_Person_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationTrainer_Specialization_SpecializationsId",
                        column: x => x.SpecializationsId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Person_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupTraining_GroupTrainingsId",
                table: "ClientGroupTraining",
                column: "GroupTrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingTrainer_TrainersId",
                table: "GroupTrainingTrainer",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ContractId",
                table: "Person",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationTrainer_TrainersId",
                table: "SpecializationTrainer",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ClientId",
                table: "Visit",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientGroupTraining");

            migrationBuilder.DropTable(
                name: "GroupTrainingTrainer");

            migrationBuilder.DropTable(
                name: "SpecializationTrainer");

            migrationBuilder.DropTable(
                name: "TrainingEquipment");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "GroupTraining");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Contract");
        }
    }
}
