using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vendor.domain.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_Products_LanguageId",
                table: "UserProducts");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "UserProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProducts_LanguageId",
                table: "UserProducts",
                newName: "IX_UserProducts_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "UserProducts",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                newName: "IX_UserProducts_LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_Products_LanguageId",
                table: "UserProducts",
                column: "LanguageId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
