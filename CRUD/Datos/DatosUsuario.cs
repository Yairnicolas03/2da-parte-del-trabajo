using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crud.Datos;

namespace CRUD
{
    internal partial class DatosUsuario : IaccesoADatos<Usuario>
    {
        private static List<Usuario> ListaUsuarios;
        private static int LastId;
        private static void read()
        {
            try
            {
                string path = "C:\\Users\\Yair\\source\\repos\\CRUD\\CRUD\\Datos\\json1.json";
                string json = File.ReadAllText(path);
                ListaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private static void Write()
        {
            try
            {
                string path = "C:\\Users\\Yair\\source\\repos\\CRUD\\CRUD\\Datos\\json1.json";
                string Json = JsonSerializer.Serialize(ListaUsuarios);
                File.WriteAllText(path, Json);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void Clear()
        {
            ListaUsuarios.Clear();
        }
        public void Add(Usuario data)
        {
            read();
            string pathID = "C:\\Users\\Yair\\source\\repos\\CRUD\\CRUD\\Datos\\usuarioLastID.txt";
            LastId = int.Parse(pathID);
            data.ID = ++LastId;
            File.WriteAllText(pathID, LastId.ToString());
            ListaUsuarios.Add(data);
            Write();
            Clear();
        }

        public void Erase(Usuario data)
        {
            read();
            foreach (Usuario u in ListaUsuarios)
            {
                if (u.ID == LastId)
                {
                    ListaUsuarios.Remove(data);
                    Write();
                    Clear() ;
                    return;
                }
            }
            Clear();
            throw new Exception("No se encontro el usuario");
        }

        public Usuario Find(Usuario data)
        {
            read();
            foreach (Usuario u in ListaUsuarios)
            {
                if (u.ID == LastId)
                {
                    Clear();
                    return u;
                }
            }
            Clear();
            throw new Exception("No se encontro el usuario");
        }

        public void Modify(Usuario data)
        {
            for (int i = 0; i < ListaUsuarios.Count; i++ )
            {
                if(ListaUsuarios[i].ID == data.ID)
                {
                    ListaUsuarios[i].Nombre = data.Nombre;
                    Write();
                    Clear();
                    return;
                }
            }
            throw new Exception("No se encontro el usuario");
        }
    }
}
