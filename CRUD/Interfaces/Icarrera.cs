using CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal interface Icarrera<T>
    {
        String Nombre {  get; set; }
        String Sigla { get; set; }
        String Titulo { get; set; }
        int Duracion { get; set; }
        Usuario FindBySigla(T data);
        Usuario NombreExist(T data);
        Usuario SiglaExist(T data);

        List<Usuario> List();
    }
}
