using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneAxis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_ProfilePicture_For_MasterUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profile_picture",
                table: "master_users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profile_picture",
                table: "master_users");
        }
    }
}
