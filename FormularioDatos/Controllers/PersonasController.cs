using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FormularioDatos;
using FormularioDatos.Models;
using FormularioDatos.Servicios;
using System.Web.Http.Cors;

namespace FormularioDatos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IPersonasService personasService;
        
        public PersonasController(IPersonasService _personasService) {
            this.personasService = _personasService;
        }

        // GET: api/Personas
        public IQueryable<Persona> GetPersonas()
        {
            return personasService.GetPersonas(); ;
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(long id)
        {
            Persona persona = personasService.Get(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(long id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

            try {
                personasService.Put(persona);
            }
            catch (Exception e) {
                throw new Exception("Ocurrio un error en el método PUT ", e.InnerException);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            persona = personasService.Create(persona);

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(long id)
        {
            Persona persona;
            try {
                persona = personasService.Delete(id);
            }
            catch (Exception e) {
                throw new Exception("Ocurrió un error durante el método DELETE ", e.InnerException);
            }
            return Ok(persona);
        }

        
    }
}