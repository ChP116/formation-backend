using LaWebAPIFactory.Context;
using LaWebAPIFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaWebAPIFactory.Dao.EF
{
    public class MatiereDaoEF : IMatiereDao
    {
        private readonly FactoryContext _context;

        public MatiereDaoEF(FactoryContext context)
        {
            this._context = context;
        }

        public bool Add(Matiere obj)
        {
            _context.Add(obj);

            int res = _context.SaveChanges();
            return res != 0 ? true : false;
        }

        public bool Delete(int Id)
        {
            var obj = Find(Id);

            _context.Remove(obj);

            int res = _context.SaveChanges();
            return res != 0 ? true : false;
        }

        public Matiere Find(int Id)
        {
            return (from m in _context.Matieres
                    where m.Id == Id
                    select m).SingleOrDefault();
        }

        public List<Matiere> FindAll()
        {
            return _context.Matieres.ToList();
        }

        public List<Matiere> FindAllByDuree(int duree)
        {
            return (from m in _context.Matieres
                    where m.Duree == duree
                    select m).ToList();
        }

        public void Save(Matiere obj)
        {
            _context.SaveChanges();
        }
    }
}
