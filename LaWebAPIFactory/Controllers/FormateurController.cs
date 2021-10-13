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
    public class FormateurController : ControllerBase
    {
        private readonly FactoryContext _context;
        public FormateurController(FactoryContext context)
        {
            _context = context;
        }
        // GET: api/<FormateurController>
        [HttpGet]
        public ActionResult<IEnumerable<Formateur>> Get()
        {
            return _context.Formateurs.ToList();
        }

        // GET api/<FormateurController>/5
        [HttpGet("{id}")]
        public ActionResult<Formateur> Get(int id)
        {
            var formateur = _context.Formateurs.Where(m => m.Id == id).SingleOrDefault();

            if (formateur == null)
            {
                return NotFound();
            }

            return formateur;
        }

        // GET api/<FormateurController>/5
        [HttpGet("{id}/custom")]
        public ActionResult<dynamic> GetCustom(int id)
        {
            var formateur = _context.Formateurs.Find(id);

            if (formateur == null)
            {
                return NotFound();
            }

            return new
            {
                Identifiant = formateur.Id,
                Titre = formateur.Externe
            };
        }

        // POST api/<FormateurController>
        [HttpPost]
        public ActionResult<Formateur> Post([FromBody] Formateur formateur)
        {
            _context.Formateurs.Add(formateur);
            _context.SaveChanges();

            return CreatedAtAction("GetFormateur", new { id = formateur.Id }, formateur);
        }

        // PUT api/<FormateurController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Formateur formateur)
        {
            if (id != formateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(formateur).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormateurExists(id))
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

        // DELETE api/<FormateurController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var formateur = _context.Formateurs.Find(id);
            if (formateur == null)
            {
                return NotFound();
            }

            _context.Formateurs.Remove(formateur);
            _context.SaveChanges();

            return NoContent();
        }

        private bool FormateurExists(int id)
        {
            return _context.Formateurs.Any(e => e.Id == id);
        }
    }
}
