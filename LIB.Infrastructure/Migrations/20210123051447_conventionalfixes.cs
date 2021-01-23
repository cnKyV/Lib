using Microsoft.EntityFrameworkCore.Migrations;

namespace LIB.Infrastructure.Migrations
{
    public partial class conventionalfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editors_Contacts_AddressId",
                table: "Editors");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Editors",
                newName: "ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Editors_AddressId",
                table: "Editors",
                newName: "IX_Editors_ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Editors_Contacts_ContactId",
                table: "Editors",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editors_Contacts_ContactId",
                table: "Editors");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Editors",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Editors_ContactId",
                table: "Editors",
                newName: "IX_Editors_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Editors_Contacts_AddressId",
                table: "Editors",
                column: "AddressId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
