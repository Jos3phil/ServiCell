using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capaDatos;

namespace capaLogica
{
    public class cRol
    {
        string idRol;
        string nombre;

        public cRol() { }

        public cRol(string idRol, string nombre)
        {
            this.idRol = idRol;
            this.nombre = nombre;
        }

        public string IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool insertar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspInsertarRol", idRol, nombre);
                Mensaje = ofila["mensaje"].ToString();
                byte codError = Convert.ToByte(ofila["codError"]);
                return codError == 0;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool modificar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspActualizarRol", idRol, nombre);
                Mensaje = ofila["mensaje"].ToString();
                byte codError = Convert.ToByte(ofila["codError"]);
                return codError == 0;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool eliminar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspEliminarRol", idRol);
                Mensaje = ofila["mensaje"].ToString();
                byte codError = Convert.ToByte(ofila["codError"]);
                return codError == 0;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public DataTable listar()
        {
            return oDatos.TraerDataTable("uspListarRol");
        }
    }
}
