using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeStore.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Washable = table.Column<bool>(type: "bit", nullable: false),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Color", "CompanyName", "HasWarranty", "ImageFileName", "Kind", "Name", "Price", "Washable", "Weight" },
                values: new object[,]
                {
                    { 1, "20", "قهوه ای", "شرکت کیف سازی", false, "1.jpg", "چرمی", "کیف چرمی", 250000, true, "900 گرم" },
                    { 2, "20", "سفید", "شرکت کیف سازی", false, "2.jpg", "پارچه", "کیف معمولی", 500000, true, "500 گرم" },
                    { 3, "3", "سفید", "نایک", true, "3.jpg", "کتان", "کفش اسپورت", 23000, false, "600 گرم" },
                    { 4, "15", "سیاه", "کفش ملی", false, "4.jpg", "چرم", "کفش مجلسی", 299000, true, "800 گرم" },
                    { 5, "2", "آبی", "کفش ملی", false, "5.jpg", "چرم", "کفش زنانه مجلسی", 259000, false, "500 گرم" },
                    { 6, "17", "قهوه ای", "شرکت چرم سازی", false, "6.jpg", "چرمی", "کیف جیبی مردانه", 21000, true, "300 گرم" },
                    { 7, "3", "آبی", "کاترپیلار", true, "7.jpg", "پارچه", "کوله پشتی", 25500, true, "300 گرم" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "1234", "Admin", "admin" },
                    { 2, "1234", "User", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ItemId",
                table: "Carts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
