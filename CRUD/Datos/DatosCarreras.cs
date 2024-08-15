using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CRUD;

namespace crud.Datos
{
    internal partial class DatosCarreras : IaccesoADatos<Carrera>
    {
        private static List<Carrera> ListaCarreras;
        private static int LastId;

        private static void read()
        {
            try
            {
                string path = "C:\\Users\\Yair\\source\\repos\\CRUD\\CRUD\\Datos\\carreras.json";
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    ListaCarreras = JsonSerializer.Deserialize<List<Carrera>>(json);
                }
                else
                {
                    ListaCarreras = new List<Carrera>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {
            try
            {
                string path = "C:\\Users\\Yair\\source\\repos\\CRUD\\CRUD\\Datos\\carreras.json";
                string json = JsonSerializer.Serialize(ListaCarreras);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Clear()
        {
            ListaCarreras.Clear();
        }

        public void Add(Carrera data)
        {
            read();
            string pathID = "C:\\Users\\Yair\\source\\repos\\CRUD\\CRUD\\Datos\\carreraLastID.txt";

            if (File.Exists(pathID))
            {
                LastId = int.Parse(File.ReadAllText(pathID));
            }
            else
            {
                LastId = 0;
            }

            data.ID = ++LastId;
            File.WriteAllText(pathID, LastId.ToString());
            ListaCarreras.Add(data);
            Write();
            Clear();
        }

        public void Erase(Carrera data)
        {
            read();
            Carrera carrera = ListaCarreras.Find(c => c.ID == data.ID);
            if (carrera != null)
            {
                ListaCarreras.Remove(carrera);
                Write();
                Clear();
            }
            else
            {
                Clear();
                throw new Exception("No se encontró la carrera");
            }
        }

        public Carrera Find(Carrera data)
        {
            read();
            Carrera carrera = ListaCarreras.Find(c => c.ID == data.ID);
            Clear();
            if (carrera != null)
            {
                return carrera;
            }
            else
            {
                throw new Exception("No se encontró la carrera");
            }
        }

        public void Modify(Carrera data)
        {
            read();
            for (int i = 0; i < ListaCarreras.Count; i++)
            {
                if (ListaCarreras[i].ID == data.ID)
                {
                    ListaCarreras[i].Nombre = data.Nombre;
                    ListaCarreras[i].Sigla = data.Sigla;
                    ListaCarreras[i].Titulo = data.Titulo;
                    ListaCarreras[i].Duracion = data.Duracion;
                    Write();
                    Clear();
                    return;
                }
            }
            Clear();
            throw new Exception("No se encontró la carrera");
        }
    }
}
