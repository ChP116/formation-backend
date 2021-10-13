using LaWebAPIFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaWebAPIFactory.Dao
{
    public interface IDao<T, PK>
    {
        List<T> FindAll();

        T Find(PK Id);

        bool Add(T obj);

        void Save(T obj);

        bool Delete(PK Id);
    }

    public interface IAdresseDao : IDao<Adresse, int>
    {

    }

    public interface ICompetenceDao : IDao<Competence, int[]>
    {

    }

    public interface ICursusDao : IDao<Cursus, int>
    {

    }

    public interface IEvaluationDao : IDao<Evaluation, int>
    {
        List<Evaluation> FindAllBytNote(int note);
    }

    public interface IFormateurDao : IDao<Formateur, int>
    {

    }

    public interface IMatiereDao : IDao<Matiere, int>
    {
        List<Matiere> FindAllByDuree(int duree);
    }

    public interface IModuleDao : IDao<Module, int>
    {

    }

    public interface IPersonneDao : IDao<Personne, int>
    {
        List<Stagiaire> FindAllStagiaire();

        List<Utilisateur> FindAllUtilisateur();
    }

    public interface ISalleDao : IDao<Salle, int>
    {

    }
}
