using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sommelier.Migrations
{
    public partial class initial : Migration
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "Variety",
                columns: table => new
                {
                    VarietyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variety", x => x.VarietyId);
                });

            migrationBuilder.CreateTable(
                name: "Winery",
                columns: table => new
                {
                    WineryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winery", x => x.WineryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Wine",
                columns: table => new
                {
                    WineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WineryId = table.Column<int>(nullable: false),
                    VarietyId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Favorite = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wine", x => x.WineId);
                    table.ForeignKey(
                        name: "FK_Wine_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    FoodCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategory", x => x.FoodCategoryId);
                    table.ForeignKey(
                        name: "FK_FoodCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCategory_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "1046bb11-3081-4296-96b1-4f54aea21dd4", 0, "ac04518b-080b-45f4-9128-81aab10dcc11", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFCEHVpMSH+BUTopJE9KNzE/y+IYOOlMb6+wWRYhWX+Zb7Lkx22GC/58J4bhw8JghQ==", null, false, "fef6e553-15f5-4f90-8bd1-a0abe981760f", false, "admin@admin.com", "admin", "admin" },
                    { "60123b69-e0ea-4b4a-a43b-1a7abaadea41", 0, "e7437028-ecb1-4dd6-aadc-c136f3cbdd5e", "ApplicationUser", "jonathan@edwards.com", true, false, null, "JONATHAN@EDWARDS.COM", "JONATHAN@EDWARDS.COM", "AQAAAAEAACcQAAAAEA/FDTeM/Dw7wmlZsbSCcEpTJvse3gMagOtuT6cKQlGYhisamoP5eE3qtOzEzNVaBg==", null, false, "f0f1bfd1-791d-42e0-8b5d-100b88c5f8b0", false, "jonathan@edwards.com", "Jonathan", "Edwards" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Dry White" },
                    { 2, "Sweet White" },
                    { 3, "Rich White" },
                    { 4, "Sparkling" },
                    { 5, "Light Red" },
                    { 6, "Medium Red" },
                    { 7, "Bold Red" },
                    { 8, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "FoodId", "Name" },
                values: new object[,]
                {
                    { 11, "Sweets" },
                    { 9, "Red Meat" },
                    { 8, "White Meat" },
                    { 7, "Rich Fish" },
                    { 6, "Fish" },
                    { 10, "Cured Meat" },
                    { 4, "Hard Cheese" },
                    { 3, "Soft Cheese" },
                    { 2, "Roasted Vegetables" },
                    { 1, "Vegetables" },
                    { 5, "Starches" }
                });

            migrationBuilder.InsertData(
                table: "Variety",
                columns: new[] { "VarietyId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 22, 5, "Gamay" },
                    { 23, 6, "Red Table Wine" },
                    { 24, 6, "Tempranillo" },
                    { 25, 6, "Sangiovese" },
                    { 26, 6, "Zinfandel" },
                    { 27, 6, "Grenache/Garnacha" },
                    { 28, 6, "Merlot" },
                    { 29, 7, "Cabernet Sauvignon" },
                    { 31, 7, "Aglianico" },
                    { 32, 7, "Malbec" },
                    { 33, 7, "Syrah/Shiraz" },
                    { 34, 8, "Late Harvest" },
                    { 35, 8, "Ice Wine" },
                    { 36, 8, "Sherry" },
                    { 37, 8, "Port" },
                    { 21, 5, "Zweigelt" },
                    { 30, 7, "Mourvedre/Monastrell" },
                    { 20, 5, "Pinot Noir" },
                    { 9, 2, "Moscato" },
                    { 18, 4, "Cava" },
                    { 3, 1, "Grüner Veltliner" },
                    { 4, 1, "Pinot Grigio" },
                    { 5, 1, "Albariño" },
                    { 6, 2, "Gewürtzraminer" },
                    { 7, 2, "Müller-Thurgau" },
                    { 8, 2, "Malvasia" },
                    { 19, 5, "St. Laurent" },
                    { 10, 2, "Riesling" },
                    { 11, 3, "Chardonnay" },
                    { 12, 3, "Roussanne" },
                    { 13, 3, "Marsanne" },
                    { 14, 3, "Viognier" },
                    { 15, 4, "Sparkling Wine" },
                    { 16, 4, "Champagne" },
                    { 17, 4, "Prosecco" },
                    { 2, 1, "Sauvignon Blanc" },
                    { 1, 1, "White Table Wine" }
                });

            migrationBuilder.InsertData(
                table: "Winery",
                columns: new[] { "WineryId", "Name" },
                values: new object[,]
                {
                    { 1, "Turley" },
                    { 2, "Arrington" }
                });

            migrationBuilder.InsertData(
                table: "FoodCategory",
                columns: new[] { "FoodCategoryId", "CategoryId", "FoodId" },
                values: new object[,]
                {
                    { 18, 6, 5 },
                    { 20, 8, 5 },
                    { 21, 1, 6 },
                    { 22, 3, 6 },
                    { 23, 4, 6 },
                    { 24, 3, 7 },
                    { 25, 5, 7 },
                    { 26, 3, 8 },
                    { 19, 7, 5 },
                    { 27, 5, 8 },
                    { 29, 6, 9 },
                    { 30, 7, 9 },
                    { 31, 2, 10 },
                    { 32, 5, 10 },
                    { 33, 6, 10 },
                    { 34, 7, 10 },
                    { 35, 8, 10 },
                    { 28, 6, 8 },
                    { 36, 2, 11 },
                    { 37, 8, 11 },
                    { 16, 4, 5 },
                    { 1, 1, 1 },
                    { 2, 4, 1 },
                    { 3, 1, 2 },
                    { 4, 5, 2 },
                    { 5, 6, 2 },
                    { 6, 2, 3 },
                    { 17, 5, 5 },
                    { 7, 3, 3 },
                    { 9, 8, 3 },
                    { 10, 2, 4 },
                    { 11, 4, 4 },
                    { 12, 6, 4 },
                    { 13, 7, 4 },
                    { 14, 1, 5 },
                    { 15, 3, 5 },
                    { 8, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Wine",
                columns: new[] { "WineId", "ApplicationUserId", "Favorite", "Name", "Quantity", "VarietyId", "WineryId", "Year" },
                values: new object[,]
                {
                    { 2, "60123b69-e0ea-4b4a-a43b-1a7abaadea41", true, "Red Fox", 4, 23, 2, 2016 },
                    { 1, "1046bb11-3081-4296-96b1-4f54aea21dd4", false, "Heminway Vineyard", 2, 26, 1, 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategory_CategoryId",
                table: "FoodCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategory_FoodId",
                table: "FoodCategory",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_ApplicationUserId",
                table: "Wine",
                column: "ApplicationUserId");
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
                name: "FoodCategory");

            migrationBuilder.DropTable(
                name: "Variety");

            migrationBuilder.DropTable(
                name: "Wine");

            migrationBuilder.DropTable(
                name: "Winery");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
