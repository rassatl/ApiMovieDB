using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMovieDB.Migrations
{
    public partial class Modif2BDFilmRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ult_datecreation",
                table: "t_e_utilisateur_utl",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 2, 21, 8, 45, 18, 563, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "flm_datesortie",
                table: "t_e_film_flm",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "ck_not_note",
                table: "t_j_notation_not",
                sql: "not_note between 0 and 5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_not_note",
                table: "t_j_notation_not");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ult_datecreation",
                table: "t_e_utilisateur_utl",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 21, 8, 45, 18, 563, DateTimeKind.Local).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "CURRENT_DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "flm_datesortie",
                table: "t_e_film_flm",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
