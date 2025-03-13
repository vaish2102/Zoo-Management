using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_Management.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnclosureNameId",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureNameId",
                table: "Animal",
                column: "EnclosureNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal",
                column: "EnclosureNameId",
                principalTable: "Enclosure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_EnclosureNameId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "EnclosureNameId",
                table: "Animal");
        }
    }
}
