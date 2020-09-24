using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagement.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PlataformName = table.Column<string>(nullable: true),
                    MediaType = table.Column<long>(nullable: false),
                    IsLent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameLoans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameId = table.Column<long>(nullable: false),
                    FriendId = table.Column<long>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameLoans_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLoans_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "4eb219bc-b9b7-4f0a-8c48-234042437d20", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "80423474-d6e4-47d8-a1e8-b668c252d3e3", "friend", "FRIEND" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "14849c62-2be1-46b3-b398-b58eb5bb635d", 0, "cc17fea6-2b4f-4372-bc61-f7357c600dad", "admin@invillia.com.br", true, false, null, "ADMIN@INVILLIA.COM.BR", "ADMIN", "AQAAAAEAACcQAAAAEM8dI2I9SZkOeAo8V0UZWy+L87CRPAd/LgrmdlVfYQj2GrAna/FRAj0+zAE1MeaTlQ==", null, false, "784860e6-eda7-4a74-a409-16dfc00c2306", false, "admin" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1019L, null, "Enzo" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1018L, null, "Henrique" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1017L, null, "Marta" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1016L, null, "Fabio" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1015L, null, "Ana" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1014L, null, "Julia" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1013L, null, "Cezar" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1012L, null, "Rodolfo" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1001L, null, "Eduardo" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1010L, null, "Jorge" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1009L, null, "Mateus" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1008L, null, "Manuela" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1007L, null, "Pedro" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1006L, null, "Fernanda" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1005L, null, "Julia" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1004L, null, "Carlos" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1002L, null, "Ayla" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1011L, null, "Antônia" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { 1003L, null, "Juliana" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1018L, true, 3L, "Resident Evil", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1019L, true, 3L, "DBZ Zenoverse", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1020L, true, 3L, "God of War", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1021L, true, 3L, "Just Dance", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1025L, true, 3L, "Red Dead Redemption", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1023L, true, 3L, "Dragon Age", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1024L, true, 3L, "Skyrim", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1017L, true, 3L, "GTA V", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1026L, true, 3L, "NBA 2k20", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1027L, true, 3L, "Fifa 2020", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1022L, true, 3L, "The Mortal Kombat", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1016L, true, 3L, "Minecraft", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1012L, true, 3L, "Uncharted", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1014L, true, 3L, "The Arkan Assilum", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1013L, true, 3L, "The Spider Man", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1011L, true, 3L, "Street Fighter", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1010L, true, 3L, "Kill Zone", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1009L, true, 3L, "Magicka", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1008L, true, 3L, "Rocket League", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1007L, true, 3L, "The Last of Us II", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1005L, true, 3L, "The Prince Of Persia", "PlayStation 4" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1004L, true, 3L, "The Witcher III", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1003L, true, 0L, "Pokemon Yellow", "Game Boy Color" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1002L, true, 0L, "Super Mario World", "SNES" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1001L, true, 1L, "Haverst Moon: Back to Nature", "PlayStation" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1015L, true, 3L, "Gear of War", "XBox One" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsLent", "MediaType", "Name", "PlataformName" },
                values: new object[] { 1006L, true, 3L, "Halo", "XBox One" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "14849c62-2be1-46b3-b398-b58eb5bb635d", "1" });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1350L, 1009L, 1019L, false, new DateTime(2016, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1349L, 1008L, 1019L, false, new DateTime(2016, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1348L, 1007L, 1019L, false, new DateTime(2016, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1347L, 1006L, 1019L, false, new DateTime(2016, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1346L, 1005L, 1019L, false, new DateTime(2016, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1345L, 1004L, 1019L, false, new DateTime(2016, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1344L, 1003L, 1019L, false, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1343L, 1002L, 1019L, false, new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1342L, 1001L, 1019L, false, new DateTime(2015, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1341L, 1019L, 1018L, false, new DateTime(2015, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1340L, 1018L, 1018L, true, new DateTime(2015, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1339L, 1017L, 1018L, false, new DateTime(2015, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1338L, 1016L, 1018L, false, new DateTime(2015, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1351L, 1010L, 1019L, false, new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1337L, 1015L, 1018L, false, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1335L, 1013L, 1018L, false, new DateTime(2015, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1334L, 1012L, 1018L, false, new DateTime(2015, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1333L, 1011L, 1018L, false, new DateTime(2015, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1332L, 1010L, 1018L, false, new DateTime(2015, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1331L, 1009L, 1018L, false, new DateTime(2015, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1330L, 1008L, 1018L, false, new DateTime(2015, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1329L, 1007L, 1018L, false, new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1328L, 1006L, 1018L, false, new DateTime(2015, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1327L, 1005L, 1018L, false, new DateTime(2015, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1326L, 1004L, 1018L, false, new DateTime(2015, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1325L, 1003L, 1018L, false, new DateTime(2015, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1324L, 1002L, 1018L, false, new DateTime(2015, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1323L, 1001L, 1018L, false, new DateTime(2015, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1336L, 1014L, 1018L, false, new DateTime(2015, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1322L, 1019L, 1017L, false, new DateTime(2015, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1352L, 1011L, 1019L, false, new DateTime(2016, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1354L, 1013L, 1019L, false, new DateTime(2016, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1382L, 1003L, 1021L, false, new DateTime(2016, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1381L, 1002L, 1021L, false, new DateTime(2016, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1380L, 1001L, 1021L, false, new DateTime(2016, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1379L, 1019L, 1020L, false, new DateTime(2016, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1378L, 1018L, 1020L, false, new DateTime(2016, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1377L, 1017L, 1020L, false, new DateTime(2016, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1376L, 1016L, 1020L, false, new DateTime(2016, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1375L, 1015L, 1020L, false, new DateTime(2016, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1374L, 1014L, 1020L, false, new DateTime(2016, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1373L, 1013L, 1020L, false, new DateTime(2016, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1372L, 1012L, 1020L, false, new DateTime(2016, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1371L, 1011L, 1020L, false, new DateTime(2016, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1370L, 1010L, 1020L, false, new DateTime(2016, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1353L, 1012L, 1019L, false, new DateTime(2016, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1369L, 1009L, 1020L, false, new DateTime(2016, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1367L, 1007L, 1020L, false, new DateTime(2016, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1366L, 1006L, 1020L, false, new DateTime(2016, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1365L, 1005L, 1020L, false, new DateTime(2016, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1364L, 1004L, 1020L, false, new DateTime(2016, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1363L, 1003L, 1020L, false, new DateTime(2016, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1362L, 1002L, 1020L, false, new DateTime(2016, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1361L, 1001L, 1020L, false, new DateTime(2016, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1360L, 1019L, 1019L, true, new DateTime(2016, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1359L, 1018L, 1019L, false, new DateTime(2016, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1358L, 1017L, 1019L, false, new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1357L, 1016L, 1019L, false, new DateTime(2016, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1356L, 1015L, 1019L, false, new DateTime(2016, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1355L, 1014L, 1019L, false, new DateTime(2016, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1368L, 1008L, 1020L, false, new DateTime(2016, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1383L, 1004L, 1021L, false, new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1321L, 1018L, 1017L, false, new DateTime(2015, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1319L, 1016L, 1017L, false, new DateTime(2015, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1286L, 1002L, 1016L, false, new DateTime(2015, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1285L, 1001L, 1016L, false, new DateTime(2015, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1284L, 1019L, 1015L, false, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1283L, 1018L, 1015L, false, new DateTime(2015, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1282L, 1017L, 1015L, false, new DateTime(2015, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1281L, 1016L, 1015L, false, new DateTime(2015, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1280L, 1015L, 1015L, true, new DateTime(2015, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1279L, 1014L, 1015L, false, new DateTime(2015, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1278L, 1013L, 1015L, false, new DateTime(2015, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1277L, 1012L, 1015L, false, new DateTime(2015, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1276L, 1011L, 1015L, false, new DateTime(2015, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1275L, 1010L, 1015L, false, new DateTime(2015, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1274L, 1009L, 1015L, false, new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1287L, 1003L, 1016L, false, new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1273L, 1008L, 1015L, false, new DateTime(2015, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1271L, 1006L, 1015L, false, new DateTime(2015, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1270L, 1005L, 1015L, false, new DateTime(2015, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1269L, 1004L, 1015L, false, new DateTime(2015, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1268L, 1003L, 1015L, false, new DateTime(2015, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1267L, 1002L, 1015L, false, new DateTime(2015, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1266L, 1001L, 1015L, false, new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1265L, 1019L, 1014L, false, new DateTime(2015, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1264L, 1018L, 1014L, false, new DateTime(2015, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1263L, 1017L, 1014L, false, new DateTime(2015, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1262L, 1016L, 1014L, false, new DateTime(2015, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1261L, 1015L, 1014L, false, new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1260L, 1014L, 1014L, true, new DateTime(2015, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1259L, 1013L, 1014L, false, new DateTime(2015, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1272L, 1007L, 1015L, false, new DateTime(2015, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1320L, 1017L, 1017L, true, new DateTime(2015, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1288L, 1004L, 1016L, false, new DateTime(2015, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1290L, 1006L, 1016L, false, new DateTime(2015, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1318L, 1015L, 1017L, false, new DateTime(2015, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1317L, 1014L, 1017L, false, new DateTime(2015, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1316L, 1013L, 1017L, false, new DateTime(2015, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1315L, 1012L, 1017L, false, new DateTime(2015, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1314L, 1011L, 1017L, false, new DateTime(2015, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1313L, 1010L, 1017L, false, new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1312L, 1009L, 1017L, false, new DateTime(2015, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1311L, 1008L, 1017L, false, new DateTime(2015, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1310L, 1007L, 1017L, false, new DateTime(2015, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1309L, 1006L, 1017L, false, new DateTime(2015, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1308L, 1005L, 1017L, false, new DateTime(2015, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1307L, 1004L, 1017L, false, new DateTime(2015, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1306L, 1003L, 1017L, false, new DateTime(2015, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1289L, 1005L, 1016L, false, new DateTime(2015, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1305L, 1002L, 1017L, false, new DateTime(2015, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1303L, 1019L, 1016L, false, new DateTime(2015, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1302L, 1018L, 1016L, false, new DateTime(2015, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1301L, 1017L, 1016L, false, new DateTime(2015, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1300L, 1016L, 1016L, true, new DateTime(2015, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1299L, 1015L, 1016L, false, new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1298L, 1014L, 1016L, false, new DateTime(2015, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1297L, 1013L, 1016L, false, new DateTime(2015, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1296L, 1012L, 1016L, false, new DateTime(2015, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1295L, 1011L, 1016L, false, new DateTime(2015, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1294L, 1010L, 1016L, false, new DateTime(2015, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1293L, 1009L, 1016L, false, new DateTime(2015, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1292L, 1008L, 1016L, false, new DateTime(2015, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1291L, 1007L, 1016L, false, new DateTime(2015, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1304L, 1001L, 1017L, false, new DateTime(2015, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1384L, 1005L, 1021L, false, new DateTime(2016, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1385L, 1006L, 1021L, false, new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1386L, 1007L, 1021L, false, new DateTime(2016, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1479L, 1005L, 1026L, false, new DateTime(2016, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1478L, 1004L, 1026L, false, new DateTime(2016, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1477L, 1003L, 1026L, false, new DateTime(2016, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1476L, 1002L, 1026L, false, new DateTime(2016, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1475L, 1001L, 1026L, false, new DateTime(2016, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1474L, 1019L, 1025L, false, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1473L, 1018L, 1025L, false, new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1472L, 1017L, 1025L, false, new DateTime(2016, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1471L, 1016L, 1025L, false, new DateTime(2016, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1470L, 1015L, 1025L, false, new DateTime(2016, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1469L, 1014L, 1025L, false, new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1468L, 1013L, 1025L, false, new DateTime(2016, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1467L, 1012L, 1025L, false, new DateTime(2016, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1480L, 1006L, 1026L, false, new DateTime(2016, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1466L, 1011L, 1025L, false, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1464L, 1009L, 1025L, false, new DateTime(2016, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1463L, 1008L, 1025L, false, new DateTime(2016, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1462L, 1007L, 1025L, false, new DateTime(2016, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1461L, 1006L, 1025L, false, new DateTime(2016, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1460L, 1005L, 1025L, false, new DateTime(2016, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1459L, 1004L, 1025L, false, new DateTime(2016, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1458L, 1003L, 1025L, false, new DateTime(2016, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1457L, 1002L, 1025L, false, new DateTime(2016, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1456L, 1001L, 1025L, false, new DateTime(2016, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1455L, 1019L, 1024L, false, new DateTime(2016, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1454L, 1018L, 1024L, false, new DateTime(2016, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1453L, 1017L, 1024L, false, new DateTime(2016, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1452L, 1016L, 1024L, false, new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1465L, 1010L, 1025L, false, new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1451L, 1015L, 1024L, false, new DateTime(2016, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1481L, 1007L, 1026L, false, new DateTime(2016, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1483L, 1009L, 1026L, false, new DateTime(2016, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1511L, 1018L, 1027L, false, new DateTime(2016, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1510L, 1017L, 1027L, false, new DateTime(2016, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1509L, 1016L, 1027L, false, new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1508L, 1015L, 1027L, false, new DateTime(2016, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1507L, 1014L, 1027L, false, new DateTime(2016, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1506L, 1013L, 1027L, false, new DateTime(2016, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1505L, 1012L, 1027L, false, new DateTime(2016, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1504L, 1011L, 1027L, false, new DateTime(2016, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1503L, 1010L, 1027L, false, new DateTime(2016, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1502L, 1009L, 1027L, false, new DateTime(2016, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1501L, 1008L, 1027L, false, new DateTime(2016, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1500L, 1007L, 1027L, false, new DateTime(2016, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1499L, 1006L, 1027L, false, new DateTime(2016, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1482L, 1008L, 1026L, false, new DateTime(2016, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1498L, 1005L, 1027L, false, new DateTime(2016, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1496L, 1003L, 1027L, false, new DateTime(2016, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1495L, 1002L, 1027L, false, new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1494L, 1001L, 1027L, false, new DateTime(2016, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1493L, 1019L, 1026L, false, new DateTime(2016, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1492L, 1018L, 1026L, false, new DateTime(2016, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1491L, 1017L, 1026L, false, new DateTime(2016, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1490L, 1016L, 1026L, false, new DateTime(2016, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1489L, 1015L, 1026L, false, new DateTime(2016, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1488L, 1014L, 1026L, false, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1487L, 1013L, 1026L, false, new DateTime(2016, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1486L, 1012L, 1026L, false, new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1485L, 1011L, 1026L, false, new DateTime(2016, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1484L, 1010L, 1026L, false, new DateTime(2016, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1497L, 1004L, 1027L, false, new DateTime(2016, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1450L, 1014L, 1024L, false, new DateTime(2016, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1449L, 1013L, 1024L, false, new DateTime(2016, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1448L, 1012L, 1024L, false, new DateTime(2016, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1414L, 1016L, 1022L, false, new DateTime(2016, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1413L, 1015L, 1022L, false, new DateTime(2016, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1412L, 1014L, 1022L, false, new DateTime(2016, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1411L, 1013L, 1022L, false, new DateTime(2016, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1410L, 1012L, 1022L, false, new DateTime(2016, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1409L, 1011L, 1022L, false, new DateTime(2016, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1408L, 1010L, 1022L, false, new DateTime(2016, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1407L, 1009L, 1022L, false, new DateTime(2016, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1406L, 1008L, 1022L, false, new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1405L, 1007L, 1022L, false, new DateTime(2016, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1404L, 1006L, 1022L, false, new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1403L, 1005L, 1022L, false, new DateTime(2016, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1402L, 1004L, 1022L, false, new DateTime(2016, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1415L, 1017L, 1022L, false, new DateTime(2016, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1401L, 1003L, 1022L, false, new DateTime(2016, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1399L, 1001L, 1022L, false, new DateTime(2016, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1398L, 1019L, 1021L, false, new DateTime(2016, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1397L, 1018L, 1021L, false, new DateTime(2016, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1396L, 1017L, 1021L, false, new DateTime(2016, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1395L, 1016L, 1021L, false, new DateTime(2016, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1394L, 1015L, 1021L, false, new DateTime(2016, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1393L, 1014L, 1021L, false, new DateTime(2016, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1392L, 1013L, 1021L, false, new DateTime(2016, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1391L, 1012L, 1021L, false, new DateTime(2016, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1390L, 1011L, 1021L, false, new DateTime(2016, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1389L, 1010L, 1021L, false, new DateTime(2016, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1388L, 1009L, 1021L, false, new DateTime(2016, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1387L, 1008L, 1021L, false, new DateTime(2016, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1400L, 1002L, 1022L, false, new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1416L, 1018L, 1022L, false, new DateTime(2016, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1417L, 1019L, 1022L, false, new DateTime(2016, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1418L, 1001L, 1023L, false, new DateTime(2016, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1447L, 1011L, 1024L, false, new DateTime(2016, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1446L, 1010L, 1024L, false, new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1445L, 1009L, 1024L, false, new DateTime(2016, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1444L, 1008L, 1024L, false, new DateTime(2016, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1443L, 1007L, 1024L, false, new DateTime(2016, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1442L, 1006L, 1024L, false, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1441L, 1005L, 1024L, false, new DateTime(2016, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1440L, 1004L, 1024L, false, new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1439L, 1003L, 1024L, false, new DateTime(2016, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1438L, 1002L, 1024L, false, new DateTime(2016, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1437L, 1001L, 1024L, false, new DateTime(2016, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1436L, 1019L, 1023L, false, new DateTime(2016, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1435L, 1018L, 1023L, false, new DateTime(2016, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1434L, 1017L, 1023L, false, new DateTime(2016, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1433L, 1016L, 1023L, false, new DateTime(2016, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1432L, 1015L, 1023L, false, new DateTime(2016, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1431L, 1014L, 1023L, false, new DateTime(2016, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1430L, 1013L, 1023L, false, new DateTime(2016, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1429L, 1012L, 1023L, false, new DateTime(2016, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1428L, 1011L, 1023L, false, new DateTime(2016, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1427L, 1010L, 1023L, false, new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1426L, 1009L, 1023L, false, new DateTime(2016, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1425L, 1008L, 1023L, false, new DateTime(2016, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1424L, 1007L, 1023L, false, new DateTime(2016, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1423L, 1006L, 1023L, false, new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1422L, 1005L, 1023L, false, new DateTime(2016, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1421L, 1004L, 1023L, false, new DateTime(2016, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1420L, 1003L, 1023L, false, new DateTime(2016, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1419L, 1002L, 1023L, false, new DateTime(2016, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1258L, 1012L, 1014L, false, new DateTime(2015, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1257L, 1011L, 1014L, false, new DateTime(2015, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1256L, 1010L, 1014L, false, new DateTime(2015, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1255L, 1009L, 1014L, false, new DateTime(2015, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1093L, 1018L, 1005L, false, new DateTime(2015, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1092L, 1017L, 1005L, false, new DateTime(2015, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1091L, 1016L, 1005L, false, new DateTime(2015, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1090L, 1015L, 1005L, false, new DateTime(2015, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1089L, 1014L, 1005L, false, new DateTime(2015, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1088L, 1013L, 1005L, false, new DateTime(2015, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1087L, 1012L, 1005L, false, new DateTime(2015, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1086L, 1011L, 1005L, false, new DateTime(2015, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1085L, 1010L, 1005L, false, new DateTime(2015, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1084L, 1009L, 1005L, false, new DateTime(2015, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1083L, 1008L, 1005L, false, new DateTime(2015, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1082L, 1007L, 1005L, false, new DateTime(2015, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1081L, 1006L, 1005L, false, new DateTime(2015, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1094L, 1019L, 1005L, false, new DateTime(2015, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1080L, 1005L, 1005L, true, new DateTime(2015, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1078L, 1003L, 1005L, false, new DateTime(2015, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1077L, 1002L, 1005L, false, new DateTime(2015, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1076L, 1001L, 1005L, false, new DateTime(2015, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1075L, 1019L, 1004L, false, new DateTime(2015, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1074L, 1018L, 1004L, false, new DateTime(2015, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1073L, 1017L, 1004L, false, new DateTime(2015, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1072L, 1016L, 1004L, false, new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1071L, 1015L, 1004L, false, new DateTime(2015, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1070L, 1014L, 1004L, false, new DateTime(2015, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1069L, 1013L, 1004L, false, new DateTime(2015, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1068L, 1012L, 1004L, false, new DateTime(2015, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1067L, 1011L, 1004L, false, new DateTime(2015, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1066L, 1010L, 1004L, false, new DateTime(2015, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1079L, 1004L, 1005L, false, new DateTime(2015, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1065L, 1009L, 1004L, false, new DateTime(2015, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1095L, 1001L, 1006L, false, new DateTime(2015, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1097L, 1003L, 1006L, false, new DateTime(2015, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1125L, 1012L, 1007L, false, new DateTime(2015, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1124L, 1011L, 1007L, false, new DateTime(2015, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1123L, 1010L, 1007L, false, new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1122L, 1009L, 1007L, false, new DateTime(2015, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1121L, 1008L, 1007L, false, new DateTime(2015, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1120L, 1007L, 1007L, true, new DateTime(2015, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1119L, 1006L, 1007L, false, new DateTime(2015, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1118L, 1005L, 1007L, false, new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1117L, 1004L, 1007L, false, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1116L, 1003L, 1007L, false, new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1115L, 1002L, 1007L, false, new DateTime(2015, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1114L, 1001L, 1007L, false, new DateTime(2015, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1113L, 1019L, 1006L, false, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1096L, 1002L, 1006L, false, new DateTime(2015, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1112L, 1018L, 1006L, false, new DateTime(2015, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1110L, 1016L, 1006L, false, new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1109L, 1015L, 1006L, false, new DateTime(2015, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1108L, 1014L, 1006L, false, new DateTime(2015, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1107L, 1013L, 1006L, false, new DateTime(2015, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1106L, 1012L, 1006L, false, new DateTime(2015, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1105L, 1011L, 1006L, false, new DateTime(2015, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1104L, 1010L, 1006L, false, new DateTime(2015, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1103L, 1009L, 1006L, false, new DateTime(2015, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1102L, 1008L, 1006L, false, new DateTime(2015, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1101L, 1007L, 1006L, false, new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1100L, 1006L, 1006L, true, new DateTime(2015, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1099L, 1005L, 1006L, false, new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1098L, 1004L, 1006L, false, new DateTime(2015, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1111L, 1017L, 1006L, false, new DateTime(2015, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1064L, 1008L, 1004L, false, new DateTime(2015, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1063L, 1007L, 1004L, false, new DateTime(2015, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1062L, 1006L, 1004L, false, new DateTime(2015, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1028L, 1010L, 1002L, false, new DateTime(2015, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1027L, 1009L, 1002L, false, new DateTime(2015, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1026L, 1008L, 1002L, false, new DateTime(2015, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1025L, 1007L, 1002L, false, new DateTime(2015, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1024L, 1006L, 1002L, false, new DateTime(2015, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1023L, 1005L, 1002L, false, new DateTime(2015, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1022L, 1004L, 1002L, false, new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1021L, 1003L, 1002L, false, new DateTime(2015, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1020L, 1002L, 1002L, true, new DateTime(2015, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1019L, 1001L, 1002L, false, new DateTime(2015, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1018L, 1019L, 1001L, false, new DateTime(2015, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1017L, 1018L, 1001L, false, new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1016L, 1017L, 1001L, false, new DateTime(2015, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1029L, 1011L, 1002L, false, new DateTime(2015, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1015L, 1016L, 1001L, false, new DateTime(2015, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1013L, 1014L, 1001L, false, new DateTime(2015, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1012L, 1013L, 1001L, false, new DateTime(2015, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1011L, 1012L, 1001L, false, new DateTime(2015, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1010L, 1011L, 1001L, false, new DateTime(2015, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1009L, 1010L, 1001L, false, new DateTime(2015, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1008L, 1009L, 1001L, false, new DateTime(2015, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1007L, 1008L, 1001L, false, new DateTime(2015, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1006L, 1007L, 1001L, false, new DateTime(2015, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1005L, 1006L, 1001L, false, new DateTime(2015, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1004L, 1005L, 1001L, false, new DateTime(2015, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1003L, 1004L, 1001L, false, new DateTime(2015, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1002L, 1003L, 1001L, false, new DateTime(2015, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1001L, 1002L, 1001L, false, new DateTime(2015, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1014L, 1015L, 1001L, false, new DateTime(2015, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1030L, 1012L, 1002L, false, new DateTime(2015, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1031L, 1013L, 1002L, false, new DateTime(2015, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1032L, 1014L, 1002L, false, new DateTime(2015, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1061L, 1005L, 1004L, false, new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1060L, 1004L, 1004L, true, new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1059L, 1003L, 1004L, false, new DateTime(2015, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1058L, 1002L, 1004L, false, new DateTime(2015, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1057L, 1001L, 1004L, false, new DateTime(2015, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1056L, 1019L, 1003L, false, new DateTime(2015, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1055L, 1018L, 1003L, false, new DateTime(2015, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1054L, 1017L, 1003L, false, new DateTime(2015, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1053L, 1016L, 1003L, false, new DateTime(2015, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1052L, 1015L, 1003L, false, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1051L, 1014L, 1003L, false, new DateTime(2015, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1050L, 1013L, 1003L, false, new DateTime(2015, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1049L, 1012L, 1003L, false, new DateTime(2015, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1048L, 1011L, 1003L, false, new DateTime(2015, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1047L, 1010L, 1003L, false, new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1046L, 1009L, 1003L, false, new DateTime(2015, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1045L, 1008L, 1003L, false, new DateTime(2015, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1044L, 1007L, 1003L, false, new DateTime(2015, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1043L, 1006L, 1003L, false, new DateTime(2015, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1042L, 1005L, 1003L, false, new DateTime(2015, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1041L, 1004L, 1003L, false, new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1040L, 1003L, 1003L, true, new DateTime(2015, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1039L, 1002L, 1003L, false, new DateTime(2015, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1038L, 1001L, 1003L, false, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1037L, 1019L, 1002L, false, new DateTime(2015, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1036L, 1018L, 1002L, false, new DateTime(2015, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1035L, 1017L, 1002L, false, new DateTime(2015, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1034L, 1016L, 1002L, false, new DateTime(2015, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1033L, 1015L, 1002L, false, new DateTime(2015, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1126L, 1013L, 1007L, false, new DateTime(2015, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1512L, 1019L, 1027L, false, new DateTime(2016, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1127L, 1014L, 1007L, false, new DateTime(2015, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1129L, 1016L, 1007L, false, new DateTime(2015, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1222L, 1014L, 1012L, false, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1221L, 1013L, 1012L, false, new DateTime(2015, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1220L, 1012L, 1012L, true, new DateTime(2015, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1219L, 1011L, 1012L, false, new DateTime(2015, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1218L, 1010L, 1012L, false, new DateTime(2015, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1217L, 1009L, 1012L, false, new DateTime(2015, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1216L, 1008L, 1012L, false, new DateTime(2015, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1215L, 1007L, 1012L, false, new DateTime(2015, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1214L, 1006L, 1012L, false, new DateTime(2015, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1213L, 1005L, 1012L, false, new DateTime(2015, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1212L, 1004L, 1012L, false, new DateTime(2015, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1211L, 1003L, 1012L, false, new DateTime(2015, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1210L, 1002L, 1012L, false, new DateTime(2015, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1223L, 1015L, 1012L, false, new DateTime(2015, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1209L, 1001L, 1012L, false, new DateTime(2015, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1207L, 1018L, 1011L, false, new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1206L, 1017L, 1011L, false, new DateTime(2015, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1205L, 1016L, 1011L, false, new DateTime(2015, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1204L, 1015L, 1011L, false, new DateTime(2015, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1203L, 1014L, 1011L, false, new DateTime(2015, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1202L, 1013L, 1011L, false, new DateTime(2015, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1201L, 1012L, 1011L, false, new DateTime(2015, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1200L, 1011L, 1011L, true, new DateTime(2015, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1199L, 1010L, 1011L, false, new DateTime(2015, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1198L, 1009L, 1011L, false, new DateTime(2015, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1197L, 1008L, 1011L, false, new DateTime(2015, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1196L, 1007L, 1011L, false, new DateTime(2015, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1195L, 1006L, 1011L, false, new DateTime(2015, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1208L, 1019L, 1011L, false, new DateTime(2015, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1194L, 1005L, 1011L, false, new DateTime(2015, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1224L, 1016L, 1012L, false, new DateTime(2015, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1226L, 1018L, 1012L, false, new DateTime(2015, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1254L, 1008L, 1014L, false, new DateTime(2015, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1253L, 1007L, 1014L, false, new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1252L, 1006L, 1014L, false, new DateTime(2015, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1251L, 1005L, 1014L, false, new DateTime(2015, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1250L, 1004L, 1014L, false, new DateTime(2015, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1249L, 1003L, 1014L, false, new DateTime(2015, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1248L, 1002L, 1014L, false, new DateTime(2015, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1247L, 1001L, 1014L, false, new DateTime(2015, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1246L, 1019L, 1013L, false, new DateTime(2015, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1245L, 1018L, 1013L, false, new DateTime(2015, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1244L, 1017L, 1013L, false, new DateTime(2015, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1243L, 1016L, 1013L, false, new DateTime(2015, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1242L, 1015L, 1013L, false, new DateTime(2015, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1225L, 1017L, 1012L, false, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1241L, 1014L, 1013L, false, new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1239L, 1012L, 1013L, false, new DateTime(2015, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1238L, 1011L, 1013L, false, new DateTime(2015, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1237L, 1010L, 1013L, false, new DateTime(2015, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1236L, 1009L, 1013L, false, new DateTime(2015, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1235L, 1008L, 1013L, false, new DateTime(2015, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1234L, 1007L, 1013L, false, new DateTime(2015, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1233L, 1006L, 1013L, false, new DateTime(2015, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1232L, 1005L, 1013L, false, new DateTime(2015, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1231L, 1004L, 1013L, false, new DateTime(2015, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1230L, 1003L, 1013L, false, new DateTime(2015, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1229L, 1002L, 1013L, false, new DateTime(2015, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1228L, 1001L, 1013L, false, new DateTime(2015, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1227L, 1019L, 1012L, false, new DateTime(2015, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1240L, 1013L, 1013L, true, new DateTime(2015, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1193L, 1004L, 1011L, false, new DateTime(2015, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1192L, 1003L, 1011L, false, new DateTime(2015, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1191L, 1002L, 1011L, false, new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1157L, 1006L, 1009L, false, new DateTime(2015, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1156L, 1005L, 1009L, false, new DateTime(2015, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1155L, 1004L, 1009L, false, new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1154L, 1003L, 1009L, false, new DateTime(2015, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1153L, 1002L, 1009L, false, new DateTime(2015, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1152L, 1001L, 1009L, false, new DateTime(2015, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1151L, 1019L, 1008L, false, new DateTime(2015, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1150L, 1018L, 1008L, false, new DateTime(2015, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1149L, 1017L, 1008L, false, new DateTime(2015, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1148L, 1016L, 1008L, false, new DateTime(2015, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1147L, 1015L, 1008L, false, new DateTime(2015, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1146L, 1014L, 1008L, false, new DateTime(2015, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1145L, 1013L, 1008L, false, new DateTime(2015, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1158L, 1007L, 1009L, false, new DateTime(2015, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1144L, 1012L, 1008L, false, new DateTime(2015, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1142L, 1010L, 1008L, false, new DateTime(2015, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1141L, 1009L, 1008L, false, new DateTime(2015, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1140L, 1008L, 1008L, true, new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1139L, 1007L, 1008L, false, new DateTime(2015, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1138L, 1006L, 1008L, false, new DateTime(2015, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1137L, 1005L, 1008L, false, new DateTime(2015, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1136L, 1004L, 1008L, false, new DateTime(2015, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1135L, 1003L, 1008L, false, new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1134L, 1002L, 1008L, false, new DateTime(2015, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1133L, 1001L, 1008L, false, new DateTime(2015, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1132L, 1019L, 1007L, false, new DateTime(2015, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1131L, 1018L, 1007L, false, new DateTime(2015, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1130L, 1017L, 1007L, false, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1143L, 1011L, 1008L, false, new DateTime(2015, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1159L, 1008L, 1009L, false, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1160L, 1009L, 1009L, true, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1161L, 1010L, 1009L, false, new DateTime(2015, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1190L, 1001L, 1011L, false, new DateTime(2015, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1189L, 1019L, 1010L, false, new DateTime(2015, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1188L, 1018L, 1010L, false, new DateTime(2015, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1187L, 1017L, 1010L, false, new DateTime(2015, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1186L, 1016L, 1010L, false, new DateTime(2015, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1185L, 1015L, 1010L, false, new DateTime(2015, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1184L, 1014L, 1010L, false, new DateTime(2015, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1183L, 1013L, 1010L, false, new DateTime(2015, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1182L, 1012L, 1010L, false, new DateTime(2015, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1181L, 1011L, 1010L, false, new DateTime(2015, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1180L, 1010L, 1010L, true, new DateTime(2015, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1179L, 1009L, 1010L, false, new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1178L, 1008L, 1010L, false, new DateTime(2015, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1177L, 1007L, 1010L, false, new DateTime(2015, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1176L, 1006L, 1010L, false, new DateTime(2015, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1175L, 1005L, 1010L, false, new DateTime(2015, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1174L, 1004L, 1010L, false, new DateTime(2015, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1173L, 1003L, 1010L, false, new DateTime(2015, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1172L, 1002L, 1010L, false, new DateTime(2015, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1171L, 1001L, 1010L, false, new DateTime(2015, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1170L, 1019L, 1009L, false, new DateTime(2015, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1169L, 1018L, 1009L, false, new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1168L, 1017L, 1009L, false, new DateTime(2015, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1167L, 1016L, 1009L, false, new DateTime(2015, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1166L, 1015L, 1009L, false, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1165L, 1014L, 1009L, false, new DateTime(2015, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1164L, 1013L, 1009L, false, new DateTime(2015, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1163L, 1012L, 1009L, false, new DateTime(2015, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1162L, 1011L, 1009L, false, new DateTime(2015, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1128L, 1015L, 1007L, false, new DateTime(2015, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GameLoans",
                columns: new[] { "Id", "FriendId", "GameId", "IsActive", "LoanDate", "ReturnDate" },
                values: new object[] { 1000L, 1001L, 1001L, true, new DateTime(2015, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_GameLoans_FriendId",
                table: "GameLoans",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLoans_GameId",
                table: "GameLoans",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "GameLoans");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
