using LaWebAPIFactory.Context;
using LaWebAPIFactory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaWebAPIFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagiairesController : ControllerBase
    {
        private readonly FactoryContext _context;
        public StagiairesController(FactoryContext context)
        {
            _context = context;
        }

        // GET: api/<StagiairesController>
        [HttpGet]
        public ActionResult<IEnumerable<Stagiaire>> Get()
        {
            return _context.Stagiaires.ToList();
        }

        // GET api/<StagiairesController>/5
        [HttpGet("{id}")]
        public ActionResult<Stagiaire> Get(int id)
        {
            var stagiaire = _context.Stagiaires.Where(m => m.Id == id).SingleOrDefault();

            if (stagiaire == null)
            {
                return NotFound();
            }

            return stagiaire;
        }

        // GET api/<StagiairesController>/5
        [HttpGet("{id}/custom")]
        public ActionResult<dynamic> GetCustom(int id)
        {
            var stagiaire = _context.Stagiaires.Find(id);

            if (stagiaire == null)
            {
                return NotFound();
            }

            return new
            {
                Identifiant = stagiaire.Id,
                Prenom = stagiaire.Prenom,
                Nom = stagiaire.Nom,
            };
        }

        // GET api/<StagiairesController>/5
        //[HttpGet("{id}/customVM")]
        //public ActionResult<StagiairesVM> GetCustomVM(int id)
        //{
        //    var Stagiaires = _context.Stagiaires.Where(m => m.Id == id).Include(m => m.Stagiaires).SingleOrDefault();

        //    if (Stagiaires == null)
        //    {
        //        return NotFound();
        //    }

        //    StagiairesVM StagiairesVM = new StagiairesVM(Stagiaires.Id, Stagiaires.Titre);

        //    foreach(Competence comp in Stagiaires.Competences)
        //    {
        //        StagiairesVM.FormateursId.Add(comp.FormateurId);
        //    }

        //    return StagiairesVM;
        //}

        // POST api/<StagiairesController>
        [HttpPost]
        public ActionResult<Stagiaire> Post([FromBody] Stagiaire stagiaire)
        {
            _context.Stagiaires.Add(stagiaire);
            _context.SaveChanges();

            return CreatedAtAction("GetStagiaires", new { id = stagiaire.Id }, stagiaire);
        }

        // PUT api/<StagiairesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stagiaire stagiaire)
        {
            if (id != stagiaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(stagiaire).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StagiairesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE api/<StagiairesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var stagiaire = _context.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return NotFound();
            }

            _context.Stagiaires.Remove(stagiaire);
            _context.SaveChanges();

            return NoContent();
        }

        private bool StagiairesExists(int id)
        {
            return _context.Stagiaires.Any(e => e.Id == id);
        }
    }
}
