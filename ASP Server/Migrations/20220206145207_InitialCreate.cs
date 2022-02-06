using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    IdClassroom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.IdClassroom);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Iddiscipline = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameDiscipline = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Iddiscipline);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonTimes",
                columns: table => new
                {
                    IdLessonTime = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LessonNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTimes", x => x.IdLessonTime);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LessonTypes",
                columns: table => new
                {
                    IdTypeLesson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTypes", x => x.IdTypeLesson);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    IdProfessors = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.IdProfessors);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudyGroups",
                columns: table => new
                {
                    IdStudyGroups = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameGroup = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGroups", x => x.IdStudyGroups);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    IdDay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.IdDay);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeekParities",
                columns: table => new
                {
                    IdweekParity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Parity = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekParities", x => x.IdweekParity);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    IdSchedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LessonTimeIdLessonTime = table.Column<int>(type: "int", nullable: true),
                    WeekParityIdweekParity = table.Column<int>(type: "int", nullable: true),
                    WeekDayIdDay = table.Column<int>(type: "int", nullable: true),
                    ClassroomIdClassroom = table.Column<int>(type: "int", nullable: true),
                    StudyGroupIdStudyGroups = table.Column<int>(type: "int", nullable: true),
                    ProfessorIdProfessors = table.Column<int>(type: "int", nullable: true),
                    DisciplineIddiscipline = table.Column<int>(type: "int", nullable: true),
                    LessonTypeIdTypeLesson = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetables", x => x.IdSchedule);
                    table.ForeignKey(
                        name: "FK_Timetables_Classrooms_ClassroomIdClassroom",
                        column: x => x.ClassroomIdClassroom,
                        principalTable: "Classrooms",
                        principalColumn: "IdClassroom");
                    table.ForeignKey(
                        name: "FK_Timetables_Disciplines_DisciplineIddiscipline",
                        column: x => x.DisciplineIddiscipline,
                        principalTable: "Disciplines",
                        principalColumn: "Iddiscipline");
                    table.ForeignKey(
                        name: "FK_Timetables_LessonTimes_LessonTimeIdLessonTime",
                        column: x => x.LessonTimeIdLessonTime,
                        principalTable: "LessonTimes",
                        principalColumn: "IdLessonTime");
                    table.ForeignKey(
                        name: "FK_Timetables_LessonTypes_LessonTypeIdTypeLesson",
                        column: x => x.LessonTypeIdTypeLesson,
                        principalTable: "LessonTypes",
                        principalColumn: "IdTypeLesson");
                    table.ForeignKey(
                        name: "FK_Timetables_Professors_ProfessorIdProfessors",
                        column: x => x.ProfessorIdProfessors,
                        principalTable: "Professors",
                        principalColumn: "IdProfessors");
                    table.ForeignKey(
                        name: "FK_Timetables_StudyGroups_StudyGroupIdStudyGroups",
                        column: x => x.StudyGroupIdStudyGroups,
                        principalTable: "StudyGroups",
                        principalColumn: "IdStudyGroups");
                    table.ForeignKey(
                        name: "FK_Timetables_WeekDays_WeekDayIdDay",
                        column: x => x.WeekDayIdDay,
                        principalTable: "WeekDays",
                        principalColumn: "IdDay");
                    table.ForeignKey(
                        name: "FK_Timetables_WeekParities_WeekParityIdweekParity",
                        column: x => x.WeekParityIdweekParity,
                        principalTable: "WeekParities",
                        principalColumn: "IdweekParity");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_ClassroomIdClassroom",
                table: "Timetables",
                column: "ClassroomIdClassroom");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_DisciplineIddiscipline",
                table: "Timetables",
                column: "DisciplineIddiscipline");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_LessonTimeIdLessonTime",
                table: "Timetables",
                column: "LessonTimeIdLessonTime");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_LessonTypeIdTypeLesson",
                table: "Timetables",
                column: "LessonTypeIdTypeLesson");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_ProfessorIdProfessors",
                table: "Timetables",
                column: "ProfessorIdProfessors");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_StudyGroupIdStudyGroups",
                table: "Timetables",
                column: "StudyGroupIdStudyGroups");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_WeekDayIdDay",
                table: "Timetables",
                column: "WeekDayIdDay");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_WeekParityIdweekParity",
                table: "Timetables",
                column: "WeekParityIdweekParity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "LessonTimes");

            migrationBuilder.DropTable(
                name: "LessonTypes");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "StudyGroups");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "WeekParities");
        }
    }
}
