using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb3.API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "varchar(200)", nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    HobbyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbies",
                columns: table => new
                {
                    PersonHobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    HobbyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbies", x => x.PersonHobbyId);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Paint or draw artwork.", "Art" },
                    { 2, "Listen or/and create music.", "Music" },
                    { 3, "Code video games.", "Game Development" },
                    { 4, "Sculpt models with clay or software.", "Sculpting" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Jeremy", "Cedendahl", "0702556191" },
                    { 2, "Basse", "Cedendahl", "07012345678" },
                    { 3, "Johan", "Fältholm", "07012335679" },
                    { 4, "Anton", "Olsson", "07012349587" },
                    { 5, "Carina", "Cedendahl", "073234232" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "HobbyId", "PersonId", "URL" },
                values: new object[,]
                {
                    { 3, 3, 1, "unity.com/" },
                    { 5, 3, 2, "unrealengine.com/en-US/" },
                    { 2, 2, 3, "soundcloud.com/jerm-495708466" },
                    { 1, 1, 4, "wikiart.org/" },
                    { 4, 4, 5, "en.wikipedia.org/wiki/Sculpture" }
                });

            migrationBuilder.InsertData(
                table: "PersonHobbies",
                columns: new[] { "PersonHobbyId", "HobbyId", "PersonId" },
                values: new object[,]
                {
                    { 3, 3, 1 },
                    { 7, 2, 1 },
                    { 5, 4, 2 },
                    { 6, 3, 2 },
                    { 2, 2, 3 },
                    { 1, 1, 4 },
                    { 4, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_HobbyId",
                table: "Links",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_HobbyId",
                table: "PersonHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_PersonId",
                table: "PersonHobbies",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonHobbies");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
