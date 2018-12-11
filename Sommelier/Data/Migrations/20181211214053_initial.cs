using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sommelier.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

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
                });

            migrationBuilder.CreateTable(
                name: "UserWine",
                columns: table => new
                {
                    UserWineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    WineId = table.Column<int>(nullable: false),
                    Favorite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWine", x => x.UserWineId);
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
                name: "Wine",
                columns: table => new
                {
                    WineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WineryId = table.Column<int>(nullable: false),
                    VarietyId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "b4216c5f-9375-4252-bbd9-5b0c80f005f8", 0, "f7d02897-9ee8-4fa0-9118-2582f0aca8e2", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKa1uHkNj1irrpODqdeLJOZKcQ6Tt6OLSb7EzP90ZNxPODYa7y1SziZ6OYCZIYQjpQ==", null, false, "157239e4-80e0-4c03-bee8-87fef6074b95", false, "admin@admin.com", "admin", "admin" },
                    { "e25e8cce-ea21-4819-bd59-390b4475e544", 0, "8853151b-3462-4ec2-bd8a-b2c5c8407d03", "ApplicationUser", "jonathan@edwards.com", true, false, null, "JONATHAN@EDWARDS.COM", "JONATHAN@EDWARDS.COM", "AQAAAAEAACcQAAAAEGmTAPTCbrT/Tvn1QemU+lHOhDA97eHQcm5E7ILt4frp6JF3RFLV4fXw9CI49KWHqA==", null, false, "5d8c967f-2816-4bf8-aaf4-a78e59331d55", false, "jonathan@edwards.com", "Jonathan", "Edwards" }
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
                table: "FoodCategory",
                columns: new[] { "FoodCategoryId", "CategoryId", "FoodId" },
                values: new object[,]
                {
                    { 21, 1, 6 },
                    { 22, 3, 6 },
                    { 23, 4, 6 },
                    { 24, 3, 7 },
                    { 25, 5, 7 },
                    { 26, 3, 8 },
                    { 27, 5, 8 },
                    { 28, 6, 8 },
                    { 31, 2, 10 },
                    { 32, 5, 10 },
                    { 33, 6, 10 },
                    { 34, 7, 10 },
                    { 35, 8, 10 },
                    { 36, 2, 11 },
                    { 37, 8, 11 },
                    { 20, 8, 5 },
                    { 29, 6, 9 },
                    { 19, 7, 5 },
                    { 30, 7, 9 },
                    { 17, 5, 5 },
                    { 2, 4, 1 },
                    { 3, 1, 2 },
                    { 4, 5, 2 },
                    { 5, 6, 2 },
                    { 6, 2, 3 },
                    { 7, 3, 3 },
                    { 18, 6, 5 },
                    { 1, 1, 1 },
                    { 8, 4, 3 },
                    { 10, 2, 4 },
                    { 11, 4, 4 },
                    { 12, 6, 4 },
                    { 13, 7, 4 },
                    { 14, 1, 5 },
                    { 15, 3, 5 },
                    { 16, 4, 5 },
                    { 9, 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserWine",
                columns: new[] { "UserWineId", "Favorite", "UserId", "WineId" },
                values: new object[,]
                {
                    { 2, false, 2, 2 },
                    { 1, false, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Variety",
                columns: new[] { "VarietyId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 36, 8, "Sherry" },
                    { 22, 5, "Gamay" },
                    { 23, 6, "Red Table Wine" },
                    { 24, 6, "Tempranillo" },
                    { 25, 6, "Sangiovese" },
                    { 26, 6, "Zinfandel" },
                    { 37, 8, "Port" },
                    { 27, 6, "Grenache/Garnacha" },
                    { 28, 6, "Merlot" },
                    { 29, 7, "Cabernet Sauvignon" },
                    { 30, 7, "Mourvedre/Monastrell" },
                    { 31, 7, "Aglianico" },
                    { 32, 7, "Malbec" },
                    { 33, 7, "Syrah/Shiraz" },
                    { 34, 8, "Late Harvest" },
                    { 35, 8, "Ice Wine" },
                    { 21, 5, "Zweigelt" },
                    { 20, 5, "Pinot Noir" },
                    { 11, 3, "Chardonnay" },
                    { 18, 4, "Cava" },
                    { 1, 1, "White Table Wine" },
                    { 2, 1, "Sauvignon Blanc" },
                    { 3, 1, "Grüner Veltliner" },
                    { 4, 1, "Pinot Grigio" },
                    { 5, 1, "Albariño" },
                    { 6, 2, "Gewürtzraminer" },
                    { 19, 5, "St. Laurent" },
                    { 8, 2, " Malvasia" },
                    { 7, 2, "Müller-Thurgau" },
                    { 10, 2, "Riesling" },
                    { 12, 3, "Roussanne" },
                    { 13, 3, "Marsanne" },
                    { 14, 3, "Viognier" },
                    { 15, 4, "Sparkling Wine" },
                    { 16, 4, "Champagne" },
                    { 17, 4, "Prosecco" },
                    { 9, 2, "Moscato" }
                });

            migrationBuilder.InsertData(
                table: "Wine",
                columns: new[] { "WineId", "ApplicationUserId", "Name", "VarietyId", "WineryId", "Year" },
                values: new object[,]
                {
                    { 1, null, "Heminway Vineyard", 26, 1, 2015 },
                    { 2, null, "Red Fox", 23, 2, 2016 }
                });

            migrationBuilder.InsertData(
                table: "Winery",
                columns: new[] { "WineryId", "Name" },
                values: new object[,]
                {
                    { 1, "Turley" },
                    { 2, "Arrington" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wine_ApplicationUserId",
                table: "Wine",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "FoodCategory");

            migrationBuilder.DropTable(
                name: "UserWine");

            migrationBuilder.DropTable(
                name: "Variety");

            migrationBuilder.DropTable(
                name: "Wine");

            migrationBuilder.DropTable(
                name: "Winery");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b4216c5f-9375-4252-bbd9-5b0c80f005f8", "f7d02897-9ee8-4fa0-9118-2582f0aca8e2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e25e8cce-ea21-4819-bd59-390b4475e544", "8853151b-3462-4ec2-bd8a-b2c5c8407d03" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
