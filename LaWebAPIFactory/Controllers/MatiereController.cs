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
    public class MatiereController : ControllerBase
    {
        private readonly FactoryContext _context;
        public MatiereController(FactoryContext context)
        {
            _context = context;
        }

        // GET: api/<MatiereController>
        [HttpGet]
        public ActionResult<IEnumerable<Matiere>> Get()
        {
            return _context.Matieres.Include(m => m.Competences).ToList();
        }

        // GET api/<MatiereController>/5
        [HttpGet("{id}")]
        public ActionResult<Matiere> Get(int id)
        {
            var matiere = _context.Matieres.Where(m => m.Id == id).Include(m => m.Competences).SingleOrDefault();

            if (matiere == null)
            {
                return NotFound();
            }

            return matiere;
        }

        // GET api/<MatiereController>/5
        [HttpGet("{id}/custom")]
        public ActionResult<dynamic> GetCustom(int id)
        {
            var matiere = _context.Matieres.Find(id);

            if (matiere == null)
            {
                return NotFound();
            }

            return new
            {
                Identifiant = matiere.Id,
                Titre = matiere.Titre
            };
        }

        // GET api/<MatiereController>/5
        [HttpGet("{id}/customVM")]
        public ActionResult<MatiereVM> GetCustomVM(int id)
        {
            var matiere = _context.Matieres.Where(m => m.Id == id).Include(m => m.Competences).SingleOrDefault();

            if (matiere == null)
            {
                return NotFound();
            }

            MatiereVM matiereVM = new MatiereVM(matiere.Id, matiere.Titre);

            foreach(Competence comp in matiere.Competences)
            {
                matiereVM.FormateursId.Add(comp.FormateurId);
            }

            return matiereVM;
        }

        // POST api/<MatiereController>
        [HttpPost]
        public ActionResult<Matiere> Post([FromBody] Matiere matiere)
        {
            _context.Matieres.Add(matiere);
            _context.SaveChanges();

            return CreatedAtAction("GetMatiere", new { id = matiere.Id }, matiere);
        }

        // PUT api/<MatiereController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(matiere).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // DELETE api/<MatiereController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matiere = _context.Matieres.Find(id);
            if (matiere == null)
            {
                return NotFound();
            }

            _context.Matieres.Remove(matiere);
            _context.SaveChanges();

            return NoContent();
        }

        private bool MatiereExists(int id)
        {
            return _context.Matieres.Any(e => e.Id == id);
        }
    }
}
