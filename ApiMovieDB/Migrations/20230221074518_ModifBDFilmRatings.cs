using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMovieDB.Migrations
{
    public partial class ModifBDFilmRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "not_note",
                table: "t_j_notation_not",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pwd",
                table: "t_e_utilisateur_utl",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pays",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "France",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_mail",
                table: "t_e_utilisateur_utl",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "utl_longitude",
                table: "t_e_utilisateur_utl",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "utl_latitude",
                table: "t_e_utilisateur_utl",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ult_datecreation",
                table: "t_e_utilisateur_utl",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 21, 8, 45, 18, 563, DateTimeKind.Local).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "flm_titre",
                table: "t_e_film_flm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "flm_duree",
                table: "t_e_film_flm",
                type: "numeric(3,0)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "not_note",
                table: "t_j_notation_not",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "utl_pwd",
                table: "t_e_utilisateur_utl",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pays",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "France");

            migrationBuilder.AlterColumn<string>(
                name: "utl_mail",
                table: "t_e_utilisateur_utl",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<float>(
                name: "utl_longitude",
                table: "t_e_utilisateur_utl",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "utl_latitude",
                table: "t_e_utilisateur_utl",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ult_datecreation",
                table: "t_e_utilisateur_utl",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 2, 21, 8, 45, 18, 563, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.AlterColumn<string>(
                name: "flm_titre",
                table: "t_e_film_flm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "flm_duree",
                table: "t_e_film_flm",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)",
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
