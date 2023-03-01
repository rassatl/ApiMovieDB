using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace ApiMovieDB.Models.EntityFramework
{
    public partial class FilmRatingDBContexts : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public FilmRatingDBContexts()
        {}
        public FilmRatingDBContexts(DbContextOptions<FilmRatingDBContexts> options) : base(options)
        {
        }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
        public virtual DbSet<Notation> Notations { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.UtilisateurId })
                    .HasName("pk_notations");

                entity.HasOne(d => d.FilmNote)
                    .WithMany(p => p.NotesFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_not_flm");

                entity.HasOne(d => d.UtilisateurNotant)
                    .WithMany(p => p.NotesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_not_utl");

                entity.HasCheckConstraint("ck_not_note","not_note between 0 and 5");
            });
            modelBuilder.Entity<Utilisateur>().Property(b => b.Pays).HasDefaultValue("France");
            modelBuilder.Entity<Utilisateur>().HasIndex(b => b.Mail).IsUnique();
            modelBuilder.Entity<Utilisateur>().Property(b => b.DateCreation).HasDefaultValueSql("CURRENT_DATE");
            //modelBuilder.Entity<Notation>().Property(b => b.Note);
            modelBuilder.Entity<Film>().Property(b => b.Duree).HasMaxLength(3);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        //Pour générer :
        //dotnet tool install --global dotnet-ef --version 6.0.13
        //dotnet-ef migrations add CreationBDFilmRatings --project ApiMovieDB
        //dotnet-ef database update --project ApiMovieDB
    }
}
