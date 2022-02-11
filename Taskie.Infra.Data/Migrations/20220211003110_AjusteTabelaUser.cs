using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskie.Infra.Data.Migrations
{
    public partial class AjusteTabelaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
