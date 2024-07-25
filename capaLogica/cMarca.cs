using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capaDatos;

namespace capaLogica
{
    public class cMarca
    {
        string idMarca;
        string nombre;

        public cMarca() { }

        public cMarca(string idMarca, string nombre)
        {
            this.idMarca = idMarca;
            this.nombre = nombre;
        }

        public string IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
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
                DataRow ofila = oDatos.TraerDataRow("uspInsertarMarca", idMarca, nombre);
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
                DataRow ofila = oDatos.TraerDataRow("uspActualizarMarca", idMarca, nombre);
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
                DataRow ofila = oDatos.TraerDataRow("uspEliminarMarca", idMarca);
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
            return oDatos.TraerDataTable("uspListarMarca");
        }
    }
}
