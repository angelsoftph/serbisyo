using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Carpenter", 0 },
                    { 2, "Driver", 0 },
                    { 3, "Electrician", 0 },
                    { 4, "Gardener", 0 },
                    { 5, "Plumber", 0 },
                    { 6, "Welder", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "super@admin.com", "Super", "Admin", new byte[] { 35, 34, 225, 31, 65, 135, 26, 199, 81, 32, 29, 6, 184, 89, 158, 63, 88, 228, 183, 240, 227, 83, 67, 6, 151, 15, 96, 189, 60, 203, 105, 230, 197, 33, 82, 3, 84, 209, 64, 227, 75, 199, 8, 170, 179, 185, 217, 190, 195, 123, 44, 102, 100, 228, 7, 200, 57, 122, 114, 19, 213, 217, 230, 236 }, new byte[] { 89, 12, 8, 83, 244, 123, 241, 28, 125, 58, 17, 22, 102, 170, 129, 11, 153, 240, 193, 124, 103, 217, 243, 50, 156, 212, 216, 32, 23, 79, 90, 9, 158, 21, 82, 23, 32, 216, 92, 127, 234, 134, 181, 189, 196, 246, 92, 157, 104, 219, 120, 165, 0, 51, 87, 54, 65, 113, 214, 237, 33, 55, 36, 124, 195, 164, 173, 11, 7, 153, 34, 247, 82, 168, 131, 84, 234, 212, 94, 91, 81, 119, 254, 56, 140, 242, 243, 25, 65, 180, 194, 249, 97, 168, 45, 176, 203, 135, 167, 249, 60, 226, 213, 242, 51, 105, 177, 246, 51, 64, 182, 116, 75, 224, 194, 78, 91, 233, 89, 205, 174, 120, 194, 201, 49, 149, 46, 122 }, "1234567", "S" },
                    { 2, "john@doe.com", "John", "Doe", new byte[] { 35, 34, 225, 31, 65, 135, 26, 199, 81, 32, 29, 6, 184, 89, 158, 63, 88, 228, 183, 240, 227, 83, 67, 6, 151, 15, 96, 189, 60, 203, 105, 230, 197, 33, 82, 3, 84, 209, 64, 227, 75, 199, 8, 170, 179, 185, 217, 190, 195, 123, 44, 102, 100, 228, 7, 200, 57, 122, 114, 19, 213, 217, 230, 236 }, new byte[] { 89, 12, 8, 83, 244, 123, 241, 28, 125, 58, 17, 22, 102, 170, 129, 11, 153, 240, 193, 124, 103, 217, 243, 50, 156, 212, 216, 32, 23, 79, 90, 9, 158, 21, 82, 23, 32, 216, 92, 127, 234, 134, 181, 189, 196, 246, 92, 157, 104, 219, 120, 165, 0, 51, 87, 54, 65, 113, 214, 237, 33, 55, 36, 124, 195, 164, 173, 11, 7, 153, 34, 247, 82, 168, 131, 84, 234, 212, 94, 91, 81, 119, 254, 56, 140, 242, 243, 25, 65, 180, 194, 249, 97, 168, 45, 176, 203, 135, 167, 249, 60, 226, 213, 242, 51, 105, 177, 246, 51, 64, 182, 116, 75, 224, 194, 78, 91, 233, 89, 205, 174, 120, 194, 201, 49, 149, 46, 122 }, "1234567", "W" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CategoryId", "Title", "UserId" },
                values: new object[] { 1, 1, "Master Carpenter", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CategoryId",
                table: "Employees",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
