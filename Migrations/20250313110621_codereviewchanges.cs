using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_Management.Migrations
{
    /// <inheritdoc />
    public partial class codereviewchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnclosureName",
                table: "Animal");

            migrationBuilder.AddColumn<int>(
                name: "EnclosureId",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureId",
                table: "Animal",
                column: "EnclosureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Enclosure_EnclosureId",
                table: "Animal",
                column: "EnclosureId",
                principalTable: "Enclosure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Enclosure_EnclosureId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_EnclosureId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "EnclosureId",
                table: "Animal");

            migrationBuilder.AddColumn<string>(
                name: "EnclosureName",
                table: "Animal",
                type: "TEXT",
                nullable: true);
        }
    }
}
