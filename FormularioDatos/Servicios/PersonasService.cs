using FormularioDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularioDatos.Servicios {
    public class PersonasService : IPersonasService {

        private IPersonasRepository personasRepository;

        public PersonasService(IPersonasRepository _personasRepository) {
            this.personasRepository = _personasRepository;
        }

        public Persona Create(Persona persona) {
            return personasRepository.Create(persona);
        }

        public Persona Delete(long id) {
            return personasRepository.Delete(id);
        }

        public Persona Get(long id) {
            return personasRepository.GetPersona(id);
        }

        public IQueryable<Persona> GetPersonas() {
            return personasRepository.GetPersonas();
        }

        public void Put(Persona persona) {
            personasRepository.PutPersona(persona);
        }
    }
}