using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Infrastructures.Data.SqlServer.Migrations
{
    public partial class editPhoneBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Phones_PhoneId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PhoneType",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneId",
                table: "Phones",
                column: "PhoneId",
                unique: true,
                filter: "[PhoneId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Persons_PhoneId",
                table: "Phones",
                column: "PhoneId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Persons_PhoneId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_PhoneId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Phones");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Phones",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PhoneType",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Persons",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");

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
    }
}
