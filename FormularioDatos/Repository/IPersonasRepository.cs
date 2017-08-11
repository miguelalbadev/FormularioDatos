using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioDatos.Repository {
    public interface IPersonasRepository {
        Persona Create(Persona persona);
        IQueryable<Persona> GetPersonas();
        Persona GetPersona(long id);
        void PutPersona(Persona persona);
        Persona Delete(long id);
        
    }
}
