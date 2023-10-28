using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBankService.Migrations
{
    /// <inheritdoc />
    public partial class Bank1ww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "bankAccount",
                columns: new[] { "IdAccount", "AccountAmount", "AccountNumber", "IdUser" },
                values: new object[] { 1, 1f, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bankAccount",
                keyColumn: "IdAccount",
                keyValue: 1);
        }
    }
}
