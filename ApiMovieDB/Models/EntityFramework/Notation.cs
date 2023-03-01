using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMovieDB.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public class Notation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("UtilisateurId")]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("FilmId")]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("not_note")]
        [Required]
        public int? Note { get; set; } = null!;

        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur UtilisateurNotant { get; set; } = null!;

        [InverseProperty("NotesFilm")]
        public virtual Film FilmNote { get; set; } = null!;

    }
}
