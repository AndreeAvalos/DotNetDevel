using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetDevel.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "field_survey",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    required = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surveyid = table.Column<int>(name: "survey_id", type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field_survey", x => x.id);
                    table.ForeignKey(
                        name: "FK_field_survey_survey_survey_id",
                        column: x => x.surveyid,
                        principalTable: "survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer_survey",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fieldsurveyid = table.Column<int>(name: "field_survey_id", type: "int", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answer_survey", x => x.id);
                    table.ForeignKey(
                        name: "FK_answer_survey_field_survey_field_survey_id",
                        column: x => x.fieldsurveyid,
                        principalTable: "field_survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "active", "deleted_at", "name", "password", "updated_at" },
                values: new object[,]
                {
                    { -2, true, null, "pruebaAdmin", "admin", null },
                    { -1, true, null, "aavalos", "root", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_answer_survey_field_survey_id",
                table: "answer_survey",
                column: "field_survey_id");

            migrationBuilder.CreateIndex(
                name: "IX_field_survey_survey_id",
                table: "field_survey",
                column: "survey_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer_survey");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "field_survey");

            migrationBuilder.DropTable(
                name: "survey");
        }
    }
}
