using System;
using System.Collections.Generic;

namespace CRUD
{
    public class Carrera : IID, IABMC<Carrera>, ICarrera1
    {
        #region IID
        public int ID { get; set; }

        public bool DniExist(int dni)
        {
            // Este método no aplica para la clase Carrera, pero se requiere por la interfaz IID.
            // Puedes lanzar una excepción o simplemente retornar false.
            throw new NotImplementedException("DniExist no es aplicable en Carrera.");
        }
        #endregion

        #region ICarrera1
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }

        private List<Carrera> carreras = new List<Carrera>();

        public ICarrera1 FindBySigla(string sigla)
        {
            return carreras.Find(c => c.Sigla == sigla);
        }

        public List<ICarrera1> List()
        {
            return new List<ICarrera1>(carreras);
        }

        public bool NameExists(string name)
        {
            return carreras.Exists(c => c.Nombre == name);
        }

        public bool SiglaExists(string sigla)
        {
            return carreras.Exists(c => c.Sigla == sigla);
        }
        #endregion

        #region IABMC
        public void Modify()
        {
            Carrera carrera = Find();
            if (carrera != null)
            {
                carrera.Nombre = this.Nombre;
                carrera.Sigla = this.Sigla;
                carrera.Titulo = this.Titulo;
                carrera.Duracion = this.Duracion;
            }
            else
            {
                throw new Exception("Carrera no encontrada.");
            }
        }

        public void Add()
        {
            carreras.Add(this);
        }

        public void Erase()
        {
            Carrera carrera = Find();
            if (carrera != null)
            {
                carreras.Remove(carrera);
            }
            else
            {
                throw new Exception("Carrera no encontrada.");
            }
        }

        public Carrera Find()
        {
            return carreras.Find(c => c.ID == this.ID);
        }
        #endregion
    }
}




