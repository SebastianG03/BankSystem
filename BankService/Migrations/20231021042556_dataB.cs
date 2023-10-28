using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBankService.Migrations
{
    /// <inheritdoc />
    public partial class dataB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "IdUser", "DNI", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[] { 1, "1", "isaac@gmail.com", "Isaac", "2234334", "233334", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "IdUser",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "user");
        }
    }
}
