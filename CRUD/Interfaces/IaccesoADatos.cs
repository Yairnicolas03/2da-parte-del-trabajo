using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    interface IaccesoADatos<T>
    {
        void Modify(T data);
        void Add(T data);
        void Erase(T data);
        T Find(T data);
    }
}
