using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class PessoaViewProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<byte>(type: "tinyint", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(45)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(45)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    staff_id = table.Column<byte>(type: "tinyint", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    username = table.Column<string>(type: "varchar(16)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(45)", nullable: false),
                    password = table.Column<string>(type: "varchar(40)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(45)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.staff_id);
                });

            // Codigo SQL colocado manualemnte (Criando View)
            var sqlView = @"CREATE VIEW top5_most_starred_actors
                            AS
	                            select top 5 a.actor_id, a.first_name, a.last_name, count(fa.film_id) as total
	                            from actor a
		                            inner join film_actor fa on fa.actor_id = a.actor_id
	                            group by a.actor_id, a.first_name, a.last_name
	                            order by total desc;";

            migrationBuilder.Sql(sqlView);

            // Codigo SQL colocado manualemnte (Criando Procedure)
            var sqlProcedure = @"CREATE PROCEDURE total_actors_from_given_category
	                                @category_name varchar(25),
	                                @total_actors int OUT
                                AS
                                BEGIN
	                                SET @total_actors = (SELECT count(distinct a.actor_id)
	                                from dbo.actor a
	                                  inner join film_actor fa on fa.actor_id = a.actor_id
	                                  inner join film f on f.film_id = fa.film_id
	                                  inner join film_category fc on fc.film_id = f.film_id
	                                  inner join category c on c.category_id = fc.category_id
	                                where c.name = @category_name);
                                END;";

            migrationBuilder.Sql(sqlProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "staff");

            // Codigo SQL colocado manualemnte (Removendo View)
            var sqlView = "DROP PROCEDURE IF EXISTS total_actors_from_given_category";
            migrationBuilder.Sql(sqlView);

            // Codigo SQL colocado manualemnte (Removendo Procedure)
            var sqlProcedure = "DROP VIEW IF EXISTS top5_most_starred_actors";
            migrationBuilder.Sql(sqlProcedure);
        }
    }
}
