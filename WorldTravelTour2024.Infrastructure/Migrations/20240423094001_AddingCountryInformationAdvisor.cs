using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldTravelTour2024.Infrastructure.Migrations
{
    public partial class AddingCountryInformationAdvisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0a339dfe-495a-4d40-a3d7-2f4bdd207aaf", 0, "3799845f-354f-467c-8d88-9fe1d2d374ec", null, false, false, null, null, null, null, null, false, "b84eea42-bcd0-4492-909e-3d6714946c34", false, null },
                    { "7ee1a258-07d1-4802-8a30-9eb2cf55c459", 0, "54ff8be0-8d71-4df9-b81e-e00152ca5c89", null, false, false, null, null, null, null, null, false, "ba364073-95ae-4dff-bcc5-08e3a9a7b9b2", false, null },
                    { "9fd86492-c2ab-4db8-a96f-7b8bdd3580e2", 0, "9cca467a-c1f9-490a-a23c-c571794d98f9", null, false, false, null, null, null, null, null, false, "02670a8d-571c-49d0-b5b7-27d53a97186e", false, null },
                    { "d9c2163b-3c19-4443-8cfd-7bfc30267089", 0, "73a87a7b-9505-4657-aa40-e52e09fc9bb8", null, false, false, null, null, null, null, null, false, "92dca551-8587-463b-9e10-31e09cd7532d", false, null }
                });
        }
    }
}
