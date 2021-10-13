using System;
using System.Collections.Generic;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public class Module
    {
        public int Id { get; set; }
        public int Duree { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int? CursusId { get; set; }
        public Cursus Cursus { get; set; }
        public int? FormateurId { get; set; }
        public Formateur Formateur { get; set; }
        public int? MatiereId { get; set; }
        public Matiere Matiere { get; set; }
        public int? SalleId { get; set; }
        public Salle Salle { get; set; }
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public Module()
        {
        }

        public Module(int duree, DateTime dateDebut, DateTime dateFin)
        {
            Duree = duree;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
    }
}
