﻿using ApiMovieDB.Models.EntityFramework;
using System.Reflection;

namespace ApiMovieDB.Models.EntityFramework
{
    public partial class Utilisateur
    {
        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   UtilisateurId == utilisateur.UtilisateurId &&
                   Nom == utilisateur.Nom &&
                   Prenom == utilisateur.Prenom &&
                   Mobile == utilisateur.Mobile &&
                   Mail == utilisateur.Mail &&
                   Pwd == utilisateur.Pwd &&
                   Rue == utilisateur.Rue &&
                   CodePostal == utilisateur.CodePostal &&
                   Ville == utilisateur.Ville &&
                   Pays == utilisateur.Pays &&
                   Latitude == utilisateur.Latitude &&
                   Longitude == utilisateur.Longitude &&
                   DateCreation == utilisateur.DateCreation &&
                   EqualityComparer<ICollection<Notation>?>.Default.Equals(NotesUtilisateur, utilisateur.NotesUtilisateur);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(UtilisateurId);
            hash.Add(Nom);
            hash.Add(Prenom);
            hash.Add(Mobile);
            hash.Add(Mail);
            hash.Add(Pwd);
            hash.Add(Rue);
            hash.Add(CodePostal);
            hash.Add(Ville);
            hash.Add(Pays);
            hash.Add(Latitude);
            hash.Add(Longitude);
            hash.Add(DateCreation);
            return hash.ToHashCode();
        }

        public override string? ToString()
        {
            return $"{Nom}/{Prenom}";
        }

    }
}
