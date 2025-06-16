using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsitePortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProfileSocialLinkRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_Profiles_ProfileId",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "SocialLinkId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "SocialLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_Profiles_ProfileId",
                table: "SocialLinks",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_Profiles_ProfileId",
                table: "SocialLinks");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "SocialLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SocialLinkId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_Profiles_ProfileId",
                table: "SocialLinks",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
