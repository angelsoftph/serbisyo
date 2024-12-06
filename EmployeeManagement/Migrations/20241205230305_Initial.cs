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
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    { 1, "super@admin.com", "Super", "Admin", new byte[] { 139, 74, 108, 254, 207, 2, 5, 100, 168, 51, 172, 15, 153, 178, 133, 222, 105, 10, 47, 135, 254, 41, 57, 14, 250, 85, 49, 124, 175, 144, 144, 188, 123, 29, 53, 15, 198, 178, 5, 214, 218, 117, 212, 50, 210, 67, 21, 111, 106, 104, 176, 188, 41, 213, 152, 188, 209, 207, 79, 179, 70, 173, 237, 12 }, new byte[] { 139, 116, 223, 234, 10, 14, 221, 86, 14, 95, 251, 242, 22, 178, 87, 218, 110, 120, 251, 160, 149, 113, 99, 162, 21, 96, 4, 254, 39, 166, 219, 25, 165, 99, 101, 240, 198, 230, 198, 53, 180, 69, 86, 46, 154, 243, 206, 58, 187, 83, 222, 148, 170, 90, 251, 177, 123, 124, 125, 95, 236, 72, 65, 169, 52, 107, 242, 159, 36, 67, 26, 90, 234, 153, 202, 145, 166, 134, 139, 213, 97, 178, 121, 204, 128, 25, 5, 46, 21, 45, 5, 196, 124, 72, 15, 125, 123, 191, 124, 98, 11, 41, 146, 117, 21, 192, 17, 238, 92, 71, 116, 188, 37, 8, 100, 254, 191, 194, 230, 205, 2, 155, 191, 94, 172, 244, 161, 28 }, "1234567", "S" },
                    { 2, "john@doe.com", "John", "Doe", new byte[] { 139, 74, 108, 254, 207, 2, 5, 100, 168, 51, 172, 15, 153, 178, 133, 222, 105, 10, 47, 135, 254, 41, 57, 14, 250, 85, 49, 124, 175, 144, 144, 188, 123, 29, 53, 15, 198, 178, 5, 214, 218, 117, 212, 50, 210, 67, 21, 111, 106, 104, 176, 188, 41, 213, 152, 188, 209, 207, 79, 179, 70, 173, 237, 12 }, new byte[] { 139, 116, 223, 234, 10, 14, 221, 86, 14, 95, 251, 242, 22, 178, 87, 218, 110, 120, 251, 160, 149, 113, 99, 162, 21, 96, 4, 254, 39, 166, 219, 25, 165, 99, 101, 240, 198, 230, 198, 53, 180, 69, 86, 46, 154, 243, 206, 58, 187, 83, 222, 148, 170, 90, 251, 177, 123, 124, 125, 95, 236, 72, 65, 169, 52, 107, 242, 159, 36, 67, 26, 90, 234, 153, 202, 145, 166, 134, 139, 213, 97, 178, 121, 204, 128, 25, 5, 46, 21, 45, 5, 196, 124, 72, 15, 125, 123, 191, 124, 98, 11, 41, 146, 117, 21, 192, 17, 238, 92, 71, 116, 188, 37, 8, 100, 254, 191, 194, 230, 205, 2, 155, 191, 94, 172, 244, 161, 28 }, "1234567", "W" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
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
