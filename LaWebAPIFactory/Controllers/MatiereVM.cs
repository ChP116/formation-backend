using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaWebAPIFactory.Controllers
{
    public class MatiereVM
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public List<int> FormateursId { get; set; } = new List<int>();

        public MatiereVM()
        {
        }

        public MatiereVM(int id, string titre)
        {
            Id = id;
            Titre = titre;
        }
    }
}
