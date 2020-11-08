﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactifyAPI.Migrations
{
    public partial class Editmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indicators_Products_ProductId",
                table: "Indicators");

            migrationBuilder.DropColumn(
                name: "ProducntId",
                table: "Indicators");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Indicators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Indicators_Products_ProductId",
                table: "Indicators",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indicators_Products_ProductId",
                table: "Indicators");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Indicators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProducntId",
                table: "Indicators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Indicators_Products_ProductId",
                table: "Indicators",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
