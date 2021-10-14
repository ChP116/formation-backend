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
    public class CompetenceController : ControllerBase
    {
        private readonly FactoryContext _context;
        public CompetenceController(FactoryContext context)
        {
            _context = context;
        }
        // GET: api/<CompetenceController>
        [HttpGet]
        public ActionResult<IEnumerable<Competence>> Get()
        {
            return _context.Competences.Include(c => c.Matiere).ToList();
        }

        // GET api/<CompetenceController>/5
        [HttpGet("{formateurId}/{matiereId}")]
        public ActionResult<Competence> Get(int formateurId, int matiereId)
        {
            var competence = _context.Competences.Where(c => c.FormateurId == formateurId && c.MatiereId == matiereId).Include(c=>c.Matiere).SingleOrDefault();

            if (competence == null)
            {
                return NotFound();
            }

            return competence;
        }

        // POST api/<CompetenceController>
        [HttpPost]
        public ActionResult<Competence> Post([FromBody] Competence competence)
        {
            _context.Competences.Add(competence);
            _context.SaveChanges();

            return CreatedAtAction("GetCompetence", competence);
        }

        // PUT api/<CompetenceController>/5
        [HttpPut("{formateurId}/{matiereId}")]
        public IActionResult Put(int formateurId, int matiereId, [FromBody] Competence competence)
        {
            if (competence.FormateurId != formateurId || competence.MatiereId != matiereId)
            {
                return BadRequest();
            }

            _context.Entry(competence).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenceExists(formateurId, matiereId))
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

        
        [HttpDelete("{formateurId}/{matiereId}")]
        public IActionResult Delete(int formateurId, int matiereId)
        {
            var competence = _context.Competences.Find(formateurId, matiereId);
            if (competence == null)
            {
                return NotFound();
            }

            _context.Competences.Remove(competence);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{formateurId}")]
        public IActionResult DeleteByF(int formateurId)
        {
            var competences = _context.Competences.Where(c=>c.FormateurId==formateurId);
            if (competences == null)
            {
                return NotFound();
            }
            foreach (var c in competences)
            {
                _context.Competences.Remove(c);
            }
            
            _context.SaveChanges();

            return NoContent();
        }



        private bool CompetenceExists(int formateurId, int matiereId)
        {
            return _context.Competences.Any(e => e.FormateurId == formateurId && e.MatiereId == matiereId);
        }
    }
}

