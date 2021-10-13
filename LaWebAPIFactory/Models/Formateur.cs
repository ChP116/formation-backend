using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LaWebAPIFactory.Models
{
    public class Formateur
    {
        public int Id { get; set; }
        public bool Externe { get; set; }

        [JsonIgnore]
        public int? UtilisateurId { get; set; }
        [JsonIgnore]
        public Utilisateur Utilisateur { get; set; }
        [JsonIgnore]
        public List<Competence> Competences { get; set; } = new List<Competence>();
        [JsonIgnore]
        public List<Module> Modules { get; set; } = new List<Module>();

        public Formateur()
        {
        }

        public Formateur(bool externe)
        {
            Externe = externe;
        }
    }
}
