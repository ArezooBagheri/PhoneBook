using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Infrastructures.Data.SqlServer.Migrations
{
    public partial class editPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Persons_PersonId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_PersonId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Phones");

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Phones_PhoneId",
                table: "Persons",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Phones_PhoneId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PersonId",
                table: "Phones",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Persons_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
