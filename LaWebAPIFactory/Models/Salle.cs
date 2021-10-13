using System;
using System.Collections.Generic;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? Capacite { get; set; }
        public bool Virtuel { get; set; }
        public Adresse Adresse{ get; set; }
        public List<Module> Modules { get; set; } = new List<Module>();

        public Salle()
        {
        }

        public Salle(string nom, int capacite, bool virtuel)
        {
            Nom = nom;
            Capacite = capacite;
            Virtuel = virtuel;
        }
    }
}
