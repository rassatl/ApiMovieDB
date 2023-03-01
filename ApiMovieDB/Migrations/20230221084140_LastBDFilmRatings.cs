using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMovieDB.Migrations
{
    public partial class LastBDFilmRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_utl_mail",
                table: "t_e_utilisateur_utl",
                column: "utl_mail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_e_utilisateur_utl_utl_mail",
                table: "t_e_utilisateur_utl");
        }
    }
}
