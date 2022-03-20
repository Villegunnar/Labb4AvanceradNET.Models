using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4AvanceradNET.API.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "UserInterests",
                columns: new[] { "UserInterestId", "InterestId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 4, 3 },
                    { 4, 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "UserInterestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "UserInterestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "UserInterestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "UserInterestId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
