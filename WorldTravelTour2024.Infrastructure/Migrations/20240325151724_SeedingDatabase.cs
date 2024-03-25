using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldTravelTour2024.Infrastructure.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_HostId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_TransportationProviderId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_TravellerId",
                table: "Agents");

            migrationBuilder.AlterTable(
                name: "Travellers",
                oldComment: "Traveller information");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Travellers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Traveller Phone Number");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Travellers",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldComment: "Traveller Money that can be spent for vacation");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Travellers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Traveller Last Name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Travellers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Traveller First Name");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Travellers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Traveller Age");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Travellers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Traveller Id")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "TransportationProviders",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldComment: "The profit from the transportations of guests");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "TransportationProviders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Transportation Provider Phone Number");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TransportationProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Transportation Provider Last Name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TransportationProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Transportation Provider First Name");

            migrationBuilder.AlterColumn<string>(
                name: "CountryNameToTransportGuest",
                table: "TransportationProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Name of the country where the guest must pe transported");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TransportationProviders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Transportation Provider Id")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Wallet",
                table: "Hosts",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldComment: "The balance of the Host payout");

            migrationBuilder.AlterColumn<int>(
                name: "Rooms",
                table: "Hosts",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldComment: "The number of rooms that the host owns");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Hosts",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldComment: "The Price for one night for a room");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hosts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Host Phone Number");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Hosts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Host Last Name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Hosts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Host First Name");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Hosts",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Host Email");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hosts",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35,
                oldComment: "Host address");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Hosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Host Id")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Continents",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TravellerId",
                table: "Agents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TransportationProviderId",
                table: "Agents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "Agents",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldComment: "The profit of the Agent");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Agent Phone Number");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Agents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Agent Last Name");

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                table: "Agents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Agents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Agent First Name");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Agent Email");

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

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "IsVisitableDuringThisSeason", "Name" },
                values: new object[,]
                {
                    { 1, true, "Europe" },
                    { 2, true, "Asia" },
                    { 3, true, "Africa" },
                    { 4, true, "South America" },
                    { 5, true, "North America" },
                    { 6, true, "Australia" },
                    { 7, true, "Antarctica" }
                });

            migrationBuilder.InsertData(
                table: "Hosts",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "PricePerNight", "Rooms", "UserId", "Wallet" },
                values: new object[] { 1, "Miami, Florida, Palm Street 1", "ringbearer@mail.com", "Frodo", "Baggins", "01973397", 200.00m, 3, null, 0.00m });

            migrationBuilder.InsertData(
                table: "TransportationProviders",
                columns: new[] { "Id", "CountryNameToTransportGuest", "FirstName", "LastName", "PhoneNumber", "Profit", "UserId" },
                values: new object[] { 1, "Egypt", "Jason", "Statham", "044258852", 0.00m, null });

            migrationBuilder.InsertData(
                table: "Travellers",
                columns: new[] { "Id", "Age", "FirstName", "HostId", "LastName", "Money", "PhoneNumber", "UserId" },
                values: new object[] { 1, 29, "John", null, "Smith", 1000.00m, "032756657", null });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Email", "FirstName", "HostId", "LastName", "PhoneNumber", "Profit", "TransportationProviderId", "TravellerId", "UserId" },
                values: new object[] { 1, "agent47@mail.com", "Agent", 1, "47", "004712345", 0.00m, 1, 1, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Hosts_HostId",
                table: "Agents",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_TransportationProviders_TransportationProviderId",
                table: "Agents",
                column: "TransportationProviderId",
                principalTable: "TransportationProviders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Travellers_TravellerId",
                table: "Agents",
                column: "TravellerId",
                principalTable: "Travellers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Hosts_HostId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_TransportationProviders_TransportationProviderId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Travellers_TravellerId",
                table: "Agents");

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a339dfe-495a-4d40-a3d7-2f4bdd207aaf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ee1a258-07d1-4802-8a30-9eb2cf55c459");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fd86492-c2ab-4db8-a96f-7b8bdd3580e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9c2163b-3c19-4443-8cfd-7bfc30267089");

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportationProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Travellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Continents");

            migrationBuilder.AlterTable(
                name: "Travellers",
                comment: "Traveller information");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Travellers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Traveller Phone Number",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Travellers",
                type: "decimal(18,4)",
                nullable: false,
                comment: "Traveller Money that can be spent for vacation",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Travellers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Traveller Last Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Travellers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Traveller First Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Travellers",
                type: "int",
                nullable: false,
                comment: "Traveller Age",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Travellers",
                type: "int",
                nullable: false,
                comment: "Traveller Id",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "TransportationProviders",
                type: "decimal(18,4)",
                nullable: false,
                comment: "The profit from the transportations of guests",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "TransportationProviders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Transportation Provider Phone Number",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TransportationProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Transportation Provider Last Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TransportationProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Transportation Provider First Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CountryNameToTransportGuest",
                table: "TransportationProviders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Name of the country where the guest must pe transported",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TransportationProviders",
                type: "int",
                nullable: false,
                comment: "Transportation Provider Id",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Wallet",
                table: "Hosts",
                type: "decimal(18,4)",
                nullable: false,
                comment: "The balance of the Host payout",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<int>(
                name: "Rooms",
                table: "Hosts",
                type: "int",
                maxLength: 10,
                nullable: false,
                comment: "The number of rooms that the host owns",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Hosts",
                type: "decimal(18,4)",
                nullable: false,
                comment: "The Price for one night for a room",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hosts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Host Phone Number",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Hosts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Host Last Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Hosts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Host First Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Hosts",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Host Email",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hosts",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                comment: "Host address",
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Hosts",
                type: "int",
                nullable: false,
                comment: "Host Id",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TravellerId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TransportationProviderId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "Agents",
                type: "decimal(18,4)",
                nullable: false,
                comment: "The profit of the Agent",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Agent Phone Number",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Agents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Agent Last Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "HostId",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Agents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Agent First Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Agent Email",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_HostId",
                table: "Agents",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_TransportationProviderId",
                table: "Agents",
                column: "TransportationProviderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_TravellerId",
                table: "Agents",
                column: "TravellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
