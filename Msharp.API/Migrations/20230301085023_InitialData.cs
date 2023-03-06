using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Msharp.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "FactoryId", "FactoryType", "Location", "Name", "ProductionCapacity" },
                values: new object[,]
                {
                    { 1, "Automobiles", "Germany", "BMW", 100 },
                    { 2, "Automobiles", "France", "Renalut", 80 },
                    { 3, "Motocycles", "Japan", "YAMAHA", 120 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "FactoryId", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 32, 1, "Mike Dan", "Car Checker" },
                    { 2, 35, 3, "Jhon Deo", "Moto Controller" },
                    { 3, 25, 3, "Louis Fabiano", "CEO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "FactoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "FactoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "FactoryId",
                keyValue: 2);
        }
    }
}
