using Microsoft.EntityFrameworkCore.Migrations;

namespace MStartPreHiringTask.DAL.Migrations
{
    public partial class RefactorAccountNumberToBeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Account_Number",
                table: "Accounts",
                column: "Account_Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Account_Number",
                table: "Accounts");
        }
    }
}
