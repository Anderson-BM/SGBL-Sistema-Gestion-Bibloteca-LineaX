﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGBL.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Generos");
        }
    }
}
