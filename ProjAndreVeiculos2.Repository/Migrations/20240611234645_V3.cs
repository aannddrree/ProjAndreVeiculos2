using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAndreVeiculos2.Repository.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BankId",
                table: "Customer",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Bank_BankId",
                table: "Customer",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Bank_BankId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_Customer_BankId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Customer");
        }
    }
}
