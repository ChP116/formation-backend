using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LaWebAPIFactory.Models
{
    public class Competence
    {

        public int FormateurId { get; set; }
        public int MatiereId { get; set; }
        [JsonIgnore]
        public Formateur Formateur { get; set; }
        [JsonIgnore]
        public Matiere Matiere { get; set; }

        public Competence()
        {
        }

        public Competence(int formateurId, int matiereId)
        {
            FormateurId = formateurId;
            MatiereId = matiereId;
        }

        public Competence(Formateur formateur, Matiere matiere)
        {
            Formateur = formateur;
            Matiere = matiere;
        }
    }
}
