using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayerCatalog.Data.PostgreSQL.Migrations
{
    public partial class DbLocalizeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerLocalization_Players_PlayerId",
                table: "PlayerLocalization");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamLocalization_Teams_TeamId",
                table: "TeamLocalization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamLocalization",
                table: "TeamLocalization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerLocalization",
                table: "PlayerLocalization");

            migrationBuilder.RenameTable(
                name: "TeamLocalization",
                newName: "TeamLocalizations");

            migrationBuilder.RenameTable(
                name: "PlayerLocalization",
                newName: "PlayerLocalizations");

            migrationBuilder.RenameIndex(
                name: "IX_TeamLocalization_TeamId",
                table: "TeamLocalizations",
                newName: "IX_TeamLocalizations_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerLocalization_PlayerId",
                table: "PlayerLocalizations",
                newName: "IX_PlayerLocalizations_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamLocalizations",
                table: "TeamLocalizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerLocalizations",
                table: "PlayerLocalizations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerLocalizations_Players_PlayerId",
                table: "PlayerLocalizations",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamLocalizations_Teams_TeamId",
                table: "TeamLocalizations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerLocalizations_Players_PlayerId",
                table: "PlayerLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamLocalizations_Teams_TeamId",
                table: "TeamLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamLocalizations",
                table: "TeamLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerLocalizations",
                table: "PlayerLocalizations");

            migrationBuilder.RenameTable(
                name: "TeamLocalizations",
                newName: "TeamLocalization");

            migrationBuilder.RenameTable(
                name: "PlayerLocalizations",
                newName: "PlayerLocalization");

            migrationBuilder.RenameIndex(
                name: "IX_TeamLocalizations_TeamId",
                table: "TeamLocalization",
                newName: "IX_TeamLocalization_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerLocalizations_PlayerId",
                table: "PlayerLocalization",
                newName: "IX_PlayerLocalization_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamLocalization",
                table: "TeamLocalization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerLocalization",
                table: "PlayerLocalization",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerLocalization_Players_PlayerId",
                table: "PlayerLocalization",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamLocalization_Teams_TeamId",
                table: "TeamLocalization",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
