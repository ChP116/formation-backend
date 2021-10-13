using System;
using System.Collections.Generic;
using System.Text;

namespace LaWebAPIFactory.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int Note { get; set; }
        public string Commentaires { get; set; }
        public int? StagiaireId { get; set; }
        public Stagiaire Stagiaire { get; set; }
        public int? ModuleId { get; set; }
        public Module Module { get; set; }

        public Evaluation()
        {
        }

        public Evaluation(int note, string commentaires)
        {
            Note = note;
            Commentaires = commentaires;
        }
    }
}
