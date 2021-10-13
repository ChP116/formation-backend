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
    public class CursusController : ControllerBase
    {
        private readonly FactoryContext _context;
        public CursusController(FactoryContext context)
        {
            _context = context;
        }

        // GET: api/<CursusController>
        [HttpGet]
        public ActionResult<IEnumerable<Cursus>> Get()
        {
            return _context.Cursus.Include(m => m.Stagiaires).ToList();
        }

        // GET api/<CursusController>/5
        [HttpGet("{id}")]
        public ActionResult<Cursus> Get(int id)
        {
            var cursus = _context.Cursus.Where(m => m.Id == id).Include(m => m.Stagiaires).SingleOrDefault();

            if (cursus == null)
            {
                return NotFound();
            }

            return cursus;
        }

        // GET api/<CursusController>/5
        [HttpGet("{id}/custom")]
        public ActionResult<dynamic> GetCustom(int id)
        {
            var cursus = _context.Cursus.Find(id);

            if (cursus == null)
            {
                return NotFound();
            }

            return new
            {
                Identifiant = cursus.Id,
                Intitule = cursus.Intitule
            };
        }

        // GET api/<CursusController>/5
        //[HttpGet("{id}/customVM")]
        //public ActionResult<CursusVM> GetCustomVM(int id)
        //{
        //    var Cursus = _context.Cursus.Where(m => m.Id == id).Include(m => m.Stagiaires).SingleOrDefault();

        //    if (Cursus == null)
        //    {
        //        return NotFound();
        //    }

        //    CursusVM CursusVM = new CursusVM(Cursus.Id, Cursus.Titre);

        //    foreach(Competence comp in Cursus.Competences)
        //    {
        //        CursusVM.FormateursId.Add(comp.FormateurId);
        //    }

        //    return CursusVM;
        //}

        // POST api/<CursusController>
        [HttpPost]
        public ActionResult<Cursus> Post([FromBody] Cursus cursus)
        {
            _context.Cursus.Add(cursus);
            _context.SaveChanges();

            return CreatedAtAction("GetCursus", new { id = cursus.Id }, cursus);
        }

        // PUT api/<CursusController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cursus cursus)
        {
            if (id != cursus.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursus).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusExists(id))
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

        // DELETE api/<CursusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cursus = _context.Cursus.Find(id);
            if (cursus == null)
            {
                return NotFound();
            }

            _context.Cursus.Remove(cursus);
            _context.SaveChanges();

            return NoContent();
        }

        private bool CursusExists(int id)
        {
            return _context.Cursus.Any(e => e.Id == id);
        }
    }
}
