using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Donatello.Migrations
{
    public partial class ExtraBoardField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Column_ColumnId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Column_Boards_BoardId",
                table: "Column");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Column",
                table: "Column");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "Column",
                newName: "Columns");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_Column_BoardId",
                table: "Columns",
                newName: "IX_Columns_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_ColumnId",
                table: "Cards",
                newName: "IX_Cards_ColumnId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Columns",
                table: "Columns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Columns_ColumnId",
                table: "Cards",
                column: "ColumnId",
                principalTable: "Columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Boards_BoardId",
                table: "Columns",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Columns_ColumnId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Boards_BoardId",
                table: "Columns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Columns",
                table: "Columns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Columns",
                newName: "Column");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameIndex(
                name: "IX_Columns_BoardId",
                table: "Column",
                newName: "IX_Column_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_ColumnId",
                table: "Card",
                newName: "IX_Card_ColumnId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Column",
                table: "Column",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Column_ColumnId",
                table: "Card",
                column: "ColumnId",
                principalTable: "Column",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Column_Boards_BoardId",
                table: "Column",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
