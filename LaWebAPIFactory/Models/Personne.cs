using System;
using System.Collections.Generic;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public abstract class Personne
    {   
        public int Id { get; set; }
        public string PersonneType { get; set; }
        public Civilite Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int? AdresseId { get; set; }
        public Adresse Adresse { get; set; }

        protected Personne()
        {
        }

        protected Personne(Civilite civilite, string nom, string prenom, string email, string telephone)
        {
            Civilite = civilite;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
        }
    }

    public enum Civilite
    {
        M,MME,MLLE
    }
}
