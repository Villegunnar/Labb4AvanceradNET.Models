using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4AvanceradNET.API.Migrations
{
    public partial class SeedDataInterestsWebbsites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "UserInterestId",
                table: "UserInterests",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                column: "UserInterestId");

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "InterestName" },
                values: new object[,]
                {
                    { 1, "Padel is a sport which combines action with fun and social interaction. It’s a great sport for players of all ages and skills, as it is both quick and easy to pick up. Most players get the basics within the first half an hour of playing so that they can enjoy the game.", "Padel" },
                    { 2, "Golf is an individual sport played by hitting a ball with a club from a tee into a hole. The object is to get the ball into the hole with the least number of swings or strokes of the club. Golf is a hugely popular sport that is enjoyed by people of all ages.", "Golf" },
                    { 3, "Basketball is a game played between two teams of five players each on a rectangular court, usually indoors. Each team tries to score by tossing the ball through the opponent's goal, an elevated horizontal hoop and net called a basket.", "Basketball" },
                    { 4, "A form of high intensity interval training, CrossFit is a strength and conditioning workout that is made up of functional movement performed at a high intensity level. These movements are actions that you perform in your day-to-day life, like squatting, pulling, pushing etc.", "Crossfit" },
                    { 5, "Running is by definition the fastest means for an animal to move on foot. It is defined in sporting terms as a gait in which at some point all feet are off the ground at the same time. It is a form of both anaerobic exercise and aerobic exercise. Running is a complex, coordinated process which involves the entire body.", "Running" }
                });

            migrationBuilder.InsertData(
                table: "Webbsites",
                columns: new[] { "Id", "InterestId", "WebbsiteAdress", "WebbsiteName" },
                values: new object[,]
                {
                    { 1, 1, "https://www.worldpadeltour.com", "World Padel Tour" },
                    { 2, 2, "https://www.pgatour.com", "PGA Tour" },
                    { 3, 3, "https://www.nba.com", "NBA" },
                    { 4, 4, "https://www.crossfit.com", "Crossfit" },
                    { 5, 5, "https://www.runnersworld.com", "Runners World" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DropIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests");

            migrationBuilder.DeleteData(
                table: "Webbsites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Webbsites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Webbsites",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Webbsites",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Webbsites",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "UserInterestId",
                table: "UserInterests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                columns: new[] { "UserId", "InterestId" });

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
        }
    }
}
