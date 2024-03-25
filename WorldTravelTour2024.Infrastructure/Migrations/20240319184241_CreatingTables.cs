using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldTravelTour2024.Infrastructure.Migrations
{
    public partial class CreatingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Agent First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Agent Last Name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Agent Phone Number"),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Agent Email"),
                    TravellerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransportationProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The profit of the Agent"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_HostId",
                        column: x => x.HostId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_TransportationProviderId",
                        column: x => x.TransportationProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_TravellerId",
                        column: x => x.TravellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVisitableDuringThisSeason = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Host Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Host First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Host Last Name"),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Host Email"),
                    Address = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Host address"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Host Phone Number"),
                    Rooms = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "The number of rooms that the host owns"),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The Price for one night for a room"),
                    Wallet = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The balance of the Host payout"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransportationProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Transportation Provider Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Transportation Provider First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Transportation Provider Last Name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Transportation Provider Phone Number"),
                    CountryNameToTransportGuest = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the country where the guest must pe transported"),
                    Profit = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The profit from the transportations of guests"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationProviders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContinentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Traveller Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Traveller First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Traveller Last Name"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Traveller Age"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Traveller Phone Number"),
                    Money = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "Traveller Money that can be spent for vacation"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travellers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Travellers_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id");
                },
                comment: "Traveller information");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_HostId",
                table: "Agents",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_TransportationProviderId",
                table: "Agents",
                column: "TransportationProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_TravellerId",
                table: "Agents",
                column: "TravellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentId",
                table: "Country",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_UserId",
                table: "Hosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationProviders_UserId",
                table: "TransportationProviders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Travellers_HostId",
                table: "Travellers",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Travellers_UserId",
                table: "Travellers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "TransportationProviders");

            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Hosts");
        }
    }
}
