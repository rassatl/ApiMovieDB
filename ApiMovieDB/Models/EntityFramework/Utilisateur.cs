using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMovieDB.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "…")]
        public string? Mobile { get; set; }

        [Required]
        [Column("utl_mail")]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string? Mail { get; set; } = null!;

        [Column("utl_pwd")]
        [StringLength(64)]
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s])[A-Za-z\d\W]{12,20}$", ErrorMessage = "…")]
        public string? Pwd { get; set; } = null!;

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; } = null!;

        [Column("utl_cp", TypeName = "char(5)")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le CP doit contenir 5 chiffres")]
        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public string? Ville { get; set; }
        
        [Column("utl_pays")]
        [StringLength(50)]
        public string? Pays { get; set; } = "France";

        [Column("utl_latitude")]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Column("ult_datecreation", TypeName = "date")]
        [Required]
        public DateTime DateCreation { get; set; } = DateTime.Now;  

        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation>? NotesUtilisateur { get; set; } = null!;
    }
}
