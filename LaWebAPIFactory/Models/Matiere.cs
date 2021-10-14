using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace LaWebAPIFactory.Models
{
    [Table("Subject")]
    public class Matiere
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [Column("Title")]
        public string Titre { get; set; }
        [Column("Duration")]
        public int? Duree { get; set; }
        [Column("Goals")]
        public string Objectifs { get; set; }
        [Column("Requirements")]
        public string PreRequis { get; set; }
        [Column("Program")]
        public string Programme { get; set; }
        [JsonIgnore]
        public List<Competence> Competences { get; set; } = new List<Competence>();
        public List<Module> Modules { get; set; } = new List<Module>();

        public Matiere()
        {
        }

        public Matiere(string titre, int duree)
        {
            Titre = titre;
            Duree = duree;
        }
    }
}
