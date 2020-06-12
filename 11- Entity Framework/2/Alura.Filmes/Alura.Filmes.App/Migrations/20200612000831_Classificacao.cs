using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class Classificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rating",
                table: "film",
                type: "varchar(10)",
                nullable: true);

            // Codigo SQL colocado manualemnte (Constraint para coluna aceitar apenas os valores determinados)
            var sql = @"ALTER TABLE [dbo].[film]
                ADD CONSTRAINT [check_rating] CHECK (
                    [rating]='NC-17' OR 
                    [rating]='R' OR 
                    [rating]='PG-13' OR 
                    [rating]='PG' OR 
                    [rating]='G');";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Codigo SQL colocado manualemnte (Removendo Constraint criada)
            var sql = "ALTER TABLE [dbo].[film] DROP CONSTRAINT[check_rating]";
            migrationBuilder.Sql(sql);

            migrationBuilder.DropColumn(
                name: "rating",
                table: "film");
        }
    }
}
