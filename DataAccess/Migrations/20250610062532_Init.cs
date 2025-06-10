using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistryName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courthouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courthouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courthouses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsertId = table.Column<int>(type: "integer", nullable: false),
                    DestinationCourthouseId = table.Column<int>(type: "integer", nullable: false),
                    TransferTypeId = table.Column<int>(type: "integer", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Courthouses_DestinationCourthouseId",
                        column: x => x.DestinationCourthouseId,
                        principalTable: "Courthouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferRequests_TransferTypes_TransferTypeId",
                        column: x => x.TransferTypeId,
                        principalTable: "TransferTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 2, "Adıyaman" },
                    { 3, "Afyonkarahisar" },
                    { 4, "Ağrı" },
                    { 5, "Amasya" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 8, "Artvin" },
                    { 9, "Aydın" },
                    { 10, "Balıkesir" },
                    { 11, "Bilecik" },
                    { 12, "Bingöl" },
                    { 13, "Bitlis" },
                    { 14, "Bolu" },
                    { 15, "Burdur" },
                    { 16, "Bursa" },
                    { 17, "Çanakkale" },
                    { 18, "Çankırı" },
                    { 19, "Çorum" },
                    { 20, "Denizli" },
                    { 21, "Diyarbakır" },
                    { 22, "Edirne" },
                    { 23, "Elazığ" },
                    { 24, "Erzincan" },
                    { 25, "Erzurum" },
                    { 26, "Eskişehir" },
                    { 27, "Gaziantep" },
                    { 28, "Giresun" },
                    { 29, "Gümüşhane" },
                    { 30, "Hakkâri" },
                    { 31, "Hatay" },
                    { 32, "Isparta" },
                    { 33, "Mersin" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" },
                    { 36, "Kars" },
                    { 37, "Kastamonu" },
                    { 38, "Kayseri" },
                    { 39, "Kırklareli" },
                    { 40, "Kırşehir" },
                    { 41, "Kocaeli" },
                    { 42, "Konya" },
                    { 43, "Kütahya" },
                    { 44, "Malatya" },
                    { 45, "Manisa" },
                    { 46, "Kahramanmaraş" },
                    { 47, "Mardin" },
                    { 48, "Muğla" },
                    { 49, "Muş" },
                    { 50, "Nevşehir" },
                    { 51, "Niğde" },
                    { 52, "Ordu" },
                    { 53, "Rize" },
                    { 54, "Sakarya" },
                    { 55, "Samsun" },
                    { 56, "Siirt" },
                    { 57, "Sinop" },
                    { 58, "Sivas" },
                    { 59, "Tekirdağ" },
                    { 60, "Tokat" },
                    { 61, "Trabzon" },
                    { 62, "Tunceli" },
                    { 63, "Şanlıurfa" },
                    { 64, "Uşak" },
                    { 65, "Van" },
                    { 66, "Yozgat" },
                    { 67, "Zonguldak" },
                    { 68, "Aksaray" },
                    { 69, "Bayburt" },
                    { 70, "Karaman" },
                    { 71, "Kırıkkale" },
                    { 72, "Batman" },
                    { 73, "Şırnak" },
                    { 74, "Bartın" },
                    { 75, "Ardahan" },
                    { 76, "Iğdır" },
                    { 77, "Yalova" },
                    { 78, "Karabük" },
                    { 79, "Kilis" },
                    { 80, "Osmaniye" },
                    { 81, "Düzce" }
                });

            migrationBuilder.InsertData(
                table: "TransferTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Eş Durum" },
                    { 2, "Tayin" },
                    { 3, "Mazeret" }
                });

            migrationBuilder.InsertData(
                table: "Courthouses",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Adana Adliyesi" },
                    { 2, 2, "Adıyaman Adliyesi" },
                    { 3, 3, "Afyonkarahisar Adliyesi" },
                    { 4, 4, "Ağrı Adliyesi" },
                    { 5, 5, "Amasya Adliyesi" },
                    { 6, 6, "Ankara Adliyesi" },
                    { 7, 7, "Antalya Adliyesi" },
                    { 8, 8, "Artvin Adliyesi" },
                    { 9, 9, "Aydın Adliyesi" },
                    { 10, 10, "Balıkesir Adliyesi" },
                    { 11, 11, "Bilecik Adliyesi" },
                    { 12, 12, "Bingöl Adliyesi" },
                    { 13, 13, "Bitlis Adliyesi" },
                    { 14, 14, "Bolu Adliyesi" },
                    { 15, 15, "Burdur Adliyesi" },
                    { 16, 16, "Bursa Adliyesi" },
                    { 17, 17, "Çanakkale Adliyesi" },
                    { 18, 18, "Çankırı Adliyesi" },
                    { 19, 19, "Çorum Adliyesi" },
                    { 20, 20, "Denizli Adliyesi" },
                    { 21, 21, "Diyarbakır Adliyesi" },
                    { 22, 22, "Edirne Adliyesi" },
                    { 23, 23, "Elazığ Adliyesi" },
                    { 24, 24, "Erzincan Adliyesi" },
                    { 25, 25, "Erzurum Adliyesi" },
                    { 26, 26, "Eskişehir Adliyesi" },
                    { 27, 27, "Gaziantep Adliyesi" },
                    { 28, 28, "Giresun Adliyesi" },
                    { 29, 29, "Gümüşhane Adliyesi" },
                    { 30, 30, "Hakkâri Adliyesi" },
                    { 31, 31, "Hatay Adliyesi" },
                    { 32, 32, "Isparta Adliyesi" },
                    { 33, 33, "Mersin Adliyesi" },
                    { 34, 34, "İstanbul Adliyesi" },
                    { 35, 35, "İzmir Adliyesi" },
                    { 36, 36, "Kars Adliyesi" },
                    { 37, 37, "Kastamonu Adliyesi" },
                    { 38, 38, "Kayseri Adliyesi" },
                    { 39, 39, "Kırklareli Adliyesi" },
                    { 40, 40, "Kırşehir Adliyesi" },
                    { 41, 41, "Kocaeli Adliyesi" },
                    { 42, 42, "Konya Adliyesi" },
                    { 43, 43, "Kütahya Adliyesi" },
                    { 44, 44, "Malatya Adliyesi" },
                    { 45, 45, "Manisa Adliyesi" },
                    { 46, 46, "Kahramanmaraş Adliyesi" },
                    { 47, 47, "Mardin Adliyesi" },
                    { 48, 48, "Muğla Adliyesi" },
                    { 49, 49, "Muş Adliyesi" },
                    { 50, 50, "Nevşehir Adliyesi" },
                    { 51, 51, "Niğde Adliyesi" },
                    { 52, 52, "Ordu Adliyesi" },
                    { 53, 53, "Rize Adliyesi" },
                    { 54, 54, "Sakarya Adliyesi" },
                    { 55, 55, "Samsun Adliyesi" },
                    { 56, 56, "Siirt Adliyesi" },
                    { 57, 57, "Sinop Adliyesi" },
                    { 58, 58, "Sivas Adliyesi" },
                    { 59, 59, "Tekirdağ Adliyesi" },
                    { 60, 60, "Tokat Adliyesi" },
                    { 61, 61, "Trabzon Adliyesi" },
                    { 62, 62, "Tunceli Adliyesi" },
                    { 63, 63, "Şanlıurfa Adliyesi" },
                    { 64, 64, "Uşak Adliyesi" },
                    { 65, 65, "Van Adliyesi" },
                    { 66, 66, "Yozgat Adliyesi" },
                    { 67, 67, "Zonguldak Adliyesi" },
                    { 68, 68, "Aksaray Adliyesi" },
                    { 69, 69, "Bayburt Adliyesi" },
                    { 70, 70, "Karaman Adliyesi" },
                    { 71, 71, "Kırıkkale Adliyesi" },
                    { 72, 72, "Batman Adliyesi" },
                    { 73, 73, "Şırnak Adliyesi" },
                    { 74, 74, "Bartın Adliyesi" },
                    { 75, 75, "Ardahan Adliyesi" },
                    { 76, 76, "Iğdır Adliyesi" },
                    { 77, 77, "Yalova Adliyesi" },
                    { 78, 78, "Karabük Adliyesi" },
                    { 79, 79, "Kilis Adliyesi" },
                    { 80, 80, "Osmaniye Adliyesi" },
                    { 81, 81, "Düzce Adliyesi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courthouses_CityId",
                table: "Courthouses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_DestinationCourthouseId",
                table: "TransferRequests",
                column: "DestinationCourthouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_TransferTypeId",
                table: "TransferRequests",
                column: "TransferTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "TransferRequests");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courthouses");

            migrationBuilder.DropTable(
                name: "TransferTypes");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
