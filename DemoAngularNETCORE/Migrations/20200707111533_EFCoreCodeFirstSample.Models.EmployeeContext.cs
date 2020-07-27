using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAngularNETCORE.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsEmployeeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 1L, "uncle.bob@gmail.com", "Uncle", "Male", "Bob", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 2L, "jan.kirsten@gmail.com", "Jan", "Female", "Kirsten", "111-222-3333" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 3L, "jenny.fish@gmail.com", "Jenny", "Female", "Fish", "444-777-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
