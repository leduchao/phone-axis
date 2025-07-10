using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneAxis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_RefreshToken_ExpireTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireAt",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireAt",
                table: "Users");
        }
    }
}
