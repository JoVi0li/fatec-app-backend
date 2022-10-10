using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FatecAppBackend.Infra.Data.Migrations
{
    public partial class Add_IdentityDocumentPhotoBack_And_IdentityDocumentPhotoFront_Columns__IdentityDocumentPhoto_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Course = table.Column<string>(type: "varchar(100)", nullable: false),
                    Time = table.Column<string>(type: "varchar(100)", nullable: false),
                    Localization = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Photo = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    IdentityDocumentNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    IdentityDocumentPhotoFront = table.Column<string>(type: " varchar(1000)", maxLength: 1000, nullable: false),
                    IdentityDocumentPhotoBack = table.Column<string>(type: " varchar(1000)", maxLength: 1000, nullable: false),
                    Gender = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValidatedUser = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserColleges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentNumber = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValidatedDocument = table.Column<bool>(type: "bit", nullable: false),
                    ProofDocument = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserColleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserColleges_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserColleges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<string>(type: "varchar(100)", nullable: false),
                    To = table.Column<string>(type: "varchar(100)", nullable: false),
                    Route = table.Column<string>(type: "varchar(500)", nullable: false),
                    OnlyWomen = table.Column<bool>(type: "bit", nullable: false),
                    TimeToGo = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false),
                    EventOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_UserColleges_EventOwnerId",
                        column: x => x.EventOwnerId,
                        principalTable: "UserColleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCollegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Participants_UserColleges_UserCollegeId",
                        column: x => x.UserCollegeId,
                        principalTable: "UserColleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventOwnerId",
                table: "Events",
                column: "EventOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_EventId",
                table: "Participants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserCollegeId",
                table: "Participants",
                column: "UserCollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserColleges_CollegeId",
                table: "UserColleges",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserColleges_StudentNumber",
                table: "UserColleges",
                column: "StudentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserColleges_UserId",
                table: "UserColleges",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "UserColleges");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
