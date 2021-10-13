using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public class Cursus
    {
        public int Id { get; set; }
        public int? GestionnaireId { get; set; }
        public Utilisateur Gestionnaire { get; set; }
        public string Intitule { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public List<Stagiaire> Stagiaires { get; set; } = new List<Stagiaire>();
        public List<Module> Modules { get; set; } = new List<Module>();

        public Cursus()
        {
        }

        public Cursus(string intitule, DateTime dateDebut, DateTime dateFin)
        {
            Intitule = intitule;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
    }
}
