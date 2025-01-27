using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class removedSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MoreResources_MoreResourceId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "ResourceLinks");

            migrationBuilder.DropTable(
                name: "MoreResources");

            migrationBuilder.DropIndex(
                name: "IX_Images_MoreResourceId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MoreResourceId",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoreResourceId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MoreResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoreResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoreResourceId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceLinks_MoreResources_MoreResourceId",
                        column: x => x.MoreResourceId,
                        principalTable: "MoreResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_MoreResourceId",
                table: "Images",
                column: "MoreResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLinks_MoreResourceId",
                table: "ResourceLinks",
                column: "MoreResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MoreResources_MoreResourceId",
                table: "Images",
                column: "MoreResourceId",
                principalTable: "MoreResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
