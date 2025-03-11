using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_Management.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTableChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal");

            migrationBuilder.AlterColumn<int>(
                name: "EnclosureNameId",
                table: "Animal",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal",
                column: "EnclosureNameId",
                principalTable: "Enclosure",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal");

            migrationBuilder.AlterColumn<int>(
                name: "EnclosureNameId",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal",
                column: "EnclosureNameId",
                principalTable: "Enclosure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
