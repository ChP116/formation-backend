using System;
using System.Collections.Generic;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Rue { get; set; }
        public string CodePostal {get;set;}
        public string Ville { get; set; }

        public Adresse()
        {
        }

        public Adresse(string rue, string codePostal, string ville)
        {
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}
