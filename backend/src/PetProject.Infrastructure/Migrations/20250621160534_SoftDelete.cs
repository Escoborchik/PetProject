using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_date",
                table: "volunteers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "volunteers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_date",
                table: "pets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "pets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deletion_date",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "deletion_date",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "pets");
        }
    }
}
