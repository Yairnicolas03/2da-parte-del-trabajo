using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public interface ICarrera1
    {
        // Propiedades de la carrera
        string Nombre { get; set; }
        string Sigla { get; set; }
        string Titulo { get; set; }
        int Duracion { get; set; }

        // Métodos específicos para la gestión de carreras
        ICarrera1 FindBySigla(string sigla);
        List<ICarrera1> List();
        bool NameExists(string name);
        bool SiglaExists(string sigla);
    }
}

