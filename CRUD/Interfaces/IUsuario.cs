using CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal interface IUsuario
    {
        string Nombre { get; set; }
        int Dni { get; set; }
        string Mail { get; set; }
        bool DniExist(int dni);
        bool MailExist(string mail);

        Usuario FindByMail(string mail);
        Usuario FindByDni(int dni);

        List<Usuario> List();
    }
}
