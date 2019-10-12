﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Api.Migrations
{
    public partial class MakeUserBookDatesNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartReadingOnUtc",
                table: "UserBook",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinisReadingOnUtc",
                table: "UserBook",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartReadingOnUtc",
                table: "UserBook",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinisReadingOnUtc",
                table: "UserBook",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
