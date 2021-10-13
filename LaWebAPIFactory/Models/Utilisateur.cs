using System;
using System.Collections.Generic;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public class Utilisateur: Personne
    {
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public Role Role { get; set; }
        public Formateur Formateur { get; set; }

        public Utilisateur()
        {
        }

        public Utilisateur(Civilite civilite, string nom, string prenom, string email, string telephone, string identifiant, string motDePasse, Role role):base(civilite, nom, prenom, email, telephone)
        {
            Identifiant = identifiant;
            MotDePasse = motDePasse;
            Role = role;
        }
    }

    public enum Role
    {
        ADMINISTRATEUR,
        GESTIONNAIRE,
        FORMATEUR
    }
}
