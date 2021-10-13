using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LaWebAPIFactory.Models
{
    public class Stagiaire: Personne
    {
        public DateTime DateNaissance { get; set; }
        public int? CursusId { get; set; }
        [JsonIgnore]
        public Cursus Cursus { get; set; }
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public Stagiaire():base()
        {
        }

        public Stagiaire(Civilite civilite, string nom, string prenom, string email, string telephone, DateTime dateNaissance): base(civilite, nom, prenom, email, telephone)
        {
            DateNaissance = dateNaissance;
        }
    }
}
