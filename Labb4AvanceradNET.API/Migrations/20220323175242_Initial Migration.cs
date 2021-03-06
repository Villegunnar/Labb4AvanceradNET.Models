using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4AvanceradNET.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Webbsites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebbsiteName = table.Column<string>(nullable: true),
                    WebbsiteAdress = table.Column<string>(nullable: true),
                    InterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webbsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webbsites_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Viktor", "Gunnarsson", "0720043420" },
                    { 2, "Erik", "Norell", "0720043421" },
                    { 3, "Lukas", "Rose", "0720043422" },
                    { 4, "Erik", "Risholm", "0720043423" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "InterestName", "UserId" },
                values: new object[,]
                {
                    { 1, "Padel is a sport which combines action with fun and social interaction. It’s a great sport for players of all ages and skills, as it is both quick and easy to pick up. Most players get the basics within the first half an hour of playing so that they can enjoy the game.", "Padel", 1 },
                    { 3, "Basketball is a game played between two teams of five players each on a rectangular court, usually indoors. Each team tries to score by tossing the ball through the opponent's goal, an elevated horizontal hoop and net called a basket.", "Basketball", 1 },
                    { 2, "Golf is an individual sport played by hitting a ball with a club from a tee into a hole. The object is to get the ball into the hole with the least number of swings or strokes of the club. Golf is a hugely popular sport that is enjoyed by people of all ages.", "Golf", 2 },
                    { 4, "A form of high intensity interval training, CrossFit is a strength and conditioning workout that is made up of functional movement performed at a high intensity level. These movements are actions that you perform in your day-to-day life, like squatting, pulling, pushing etc.", "Crossfit", 3 },
                    { 5, "Running is by definition the fastest means for an animal to move on foot. It is defined in sporting terms as a gait in which at some point all feet are off the ground at the same time. It is a form of both anaerobic exercise and aerobic exercise. Running is a complex, coordinated process which involves the entire body.", "Running", 4 }
                });

            migrationBuilder.InsertData(
                table: "Webbsites",
                columns: new[] { "Id", "InterestId", "WebbsiteAdress", "WebbsiteName" },
                values: new object[,]
                {
                    { 1, 1, "https://www.worldpadeltour.com", "World Padel Tour" },
                    { 3, 3, "https://www.nba.com", "NBA" },
                    { 2, 2, "https://www.pgatour.com", "PGA Tour" },
                    { 4, 4, "https://www.crossfit.com", "Crossfit" },
                    { 5, 5, "https://www.runnersworld.com", "Runners World" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_UserId",
                table: "Interests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Webbsites_InterestId",
                table: "Webbsites",
                column: "InterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Webbsites");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
