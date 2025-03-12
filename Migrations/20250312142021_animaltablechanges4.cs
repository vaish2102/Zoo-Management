using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_Management.Migrations
{
    /// <inheritdoc />
    public partial class animaltablechanges4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "EnclosureName",
                table: "Animal",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnclosureName",
                table: "Animal");

            migrationBuilder.AddColumn<int>(
                name: "EnclosureNameId",
                table: "Animal",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureNameId",
                table: "Animal",
                column: "EnclosureNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Enclosure_EnclosureNameId",
                table: "Animal",
                column: "EnclosureNameId",
                principalTable: "Enclosure",
                principalColumn: "Id");
        }
    }
}
