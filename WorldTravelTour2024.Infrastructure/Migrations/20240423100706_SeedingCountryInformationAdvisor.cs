using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldTravelTour2024.Infrastructure.Migrations
{
    public partial class SeedingCountryInformationAdvisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c192cce-b4a9-41fc-b227-2216df27f411");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95f69e30-b419-4aa9-89a2-a51c123a7c4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4297173-ef61-47d0-99d6-1cc376b547d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef6b82aa-bb10-4f44-81f5-4ccc7864c1c4");

            migrationBuilder.CreateTable(
                name: "CountryInformationAdvisor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryInformationAdvisor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1afcf719-f511-469c-b889-abf6d1a5f134", 0, "6e1dbc07-698e-4dcc-bf0c-72e9d529afbc", null, false, false, null, null, null, null, null, false, "35441cde-bb24-4e0f-aad1-6b7ef35687ee", false, null },
                    { "449b6e82-9cce-4cdf-a837-9cc64b35c0a1", 0, "803c88b7-65c0-4668-a20c-4776975f369a", null, false, false, null, null, null, null, null, false, "571eb9b0-2a52-4ae6-bf74-a7f7df0104ce", false, null },
                    { "9664819c-24ff-4a5c-a3ac-39a9533d26b0", 0, "02f5cb55-bf5e-47d7-978a-e7e95a4a54c9", null, false, false, null, null, null, null, null, false, "26b75467-d4b0-47c6-94e4-5808115c27d3", false, null },
                    { "bc967507-a2eb-495e-aa35-4f5088165848", 0, "3e8b0394-b135-4c06-a937-7af76fb48b89", null, false, false, null, null, null, null, null, false, "ee445565-5c5d-4b20-897c-eb605935dde2", false, null }
                });            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryInformationAdvisor");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1afcf719-f511-469c-b889-abf6d1a5f134");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "449b6e82-9cce-4cdf-a837-9cc64b35c0a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9664819c-24ff-4a5c-a3ac-39a9533d26b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc967507-a2eb-495e-aa35-4f5088165848");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c192cce-b4a9-41fc-b227-2216df27f411", 0, "509f5ed5-3fab-458a-9d23-fc336af6abdd", null, false, false, null, null, null, null, null, false, "c91d55fb-0bc9-4eac-81e1-bda5e9e1e110", false, null },
                    { "95f69e30-b419-4aa9-89a2-a51c123a7c4a", 0, "32551880-59f5-42ed-8306-8f299b583b19", null, false, false, null, null, null, null, null, false, "ee70979a-07be-4671-b4a2-622a961084b5", false, null },
                    { "c4297173-ef61-47d0-99d6-1cc376b547d4", 0, "3a5733a7-0ddb-400a-b7f4-464d8994238c", null, false, false, null, null, null, null, null, false, "98726bc8-e45a-4c5c-bc19-dec66c3a46a0", false, null },
                    { "ef6b82aa-bb10-4f44-81f5-4ccc7864c1c4", 0, "b90bba3e-ae76-44a1-97dd-cc1cdcb3bd25", null, false, false, null, null, null, null, null, false, "ad2bbe00-d727-492c-8fef-9194794c0661", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Travellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "");
        }
    }
}
