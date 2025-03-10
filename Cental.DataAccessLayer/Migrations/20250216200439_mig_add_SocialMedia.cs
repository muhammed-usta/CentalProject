using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cental.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_SocialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "SocialMedia",
                table: "Contacts",
                newName: "OpenDay");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Contacts",
                newName: "OffDay");

            migrationBuilder.AddColumn<int>(
                name: "SocialMediaId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    SocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.SocialMediaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SocialMediaId",
                table: "Contacts",
                column: "SocialMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SocialMedias_SocialMediaId",
                table: "Contacts",
                column: "SocialMediaId",
                principalTable: "SocialMedias",
                principalColumn: "SocialMediaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SocialMedias_SocialMediaId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SocialMediaId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SocialMediaId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "OpenDay",
                table: "Contacts",
                newName: "SocialMedia");

            migrationBuilder.RenameColumn(
                name: "OffDay",
                table: "Contacts",
                newName: "Day");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
