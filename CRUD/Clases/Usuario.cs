using System;
using System.Collections.Generic;
using System.Net;
using System.IO;


namespace CRUD
{
    class Usuario: IABMC<Usuario>,IUsuario
    {
        private static Datos datos = new Datos();
        public List<Usuario> List()
        {
            return null;
        }
        #region ID
        public int ID { get; set; }
        #endregion
        #region IUsuario
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Mail { get; set; }
        public bool DniExist(int dni)
        {
            return false;
        }
        
        public bool MailExist(string mail)
        {

                return false;
        }
        public Usuario FindByDni(int dni)
        {
            return null;
        }

        public Usuario FindByMail(string mail)
        {
            return null;
        }
        #endregion
        #region IABMC
        public void Add()
        {
            datos.Add(this);
        }
        public Usuario Find()
        {
            datos.Find(this);
            return this;
        }

        public void Modify()
        {
            datos.Modify(this);
        }

        public void Erase()
        {
            datos.Erase(this);
        }
        #endregion
    }
}
