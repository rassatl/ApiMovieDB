using ApiMovieDB.Models.EntityFramework;
using ApiMovieDB.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMovieDB.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly FilmRatingDBContexts? filmsDbContext;
        public UtilisateurManager() { }
        public UtilisateurManager(FilmRatingDBContexts context)
        {
            filmsDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllAsync()
        {
            return await filmsDbContext.Utilisateurs.ToListAsync();
        }
        public async Task<ActionResult<Utilisateur>> GetByIdAsync(int id)
        {
            return await filmsDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.UtilisateurId == id);
        }
        public async Task<ActionResult<Utilisateur>> GetByStringAsync(string mail)
        {
            return await filmsDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Utilisateur entity)
        {
            await filmsDbContext.Utilisateurs.AddAsync(entity);
            await filmsDbContext.SaveChangesAsync();
        }
        public async Task Update(Utilisateur utilisateur, Utilisateur entity)
        {
            filmsDbContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.UtilisateurId = entity.UtilisateurId;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.CodePostal = entity.CodePostal;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotesUtilisateur = entity.NotesUtilisateur;
            await filmsDbContext.SaveChangesAsync();
        }
        public async Task Delete(Utilisateur utilisateur)
        {
            filmsDbContext.Utilisateurs.Remove(utilisateur);
            await filmsDbContext.SaveChangesAsync();
        }



    }
}
