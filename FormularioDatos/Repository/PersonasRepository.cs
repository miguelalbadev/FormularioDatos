using FormularioDatos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularioDatos.Repository {
    public class PersonasRepository : IPersonasRepository {

        public Persona Create(Persona persona) {
            return ApplicationDbContext.applicationDbContext.Personas.Create();
        }

        public Persona Delete(long id) {
            Persona persona = ApplicationDbContext.applicationDbContext.Personas.Find(id);
            if (persona == null) {
                throw new Exception("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Personas.Remove(persona);
            return persona;

        }

        public Persona GetPersona(long id) {
            return ApplicationDbContext.applicationDbContext.Personas.Find(id);
        }

        public IQueryable<Persona> GetPersonas() {
            IList<Persona> lista = new List<Persona>(ApplicationDbContext.applicationDbContext.Personas);
            return lista.AsQueryable();
        }

        public void PutPersona(Persona persona) {
            if (ApplicationDbContext.applicationDbContext.Personas.Count(e => e.Id == persona.Id) == 0) {
                throw new Exception("No he encontrado la entidad ");
            }
            ApplicationDbContext.applicationDbContext.Entry(persona).State = EntityState.Modified;
        }

        public Persona PostPersona(Persona persona) {
            return ApplicationDbContext.applicationDbContext.Personas.Add(persona);
        }
    }
}