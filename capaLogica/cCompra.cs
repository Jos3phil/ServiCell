using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capaDatos;

namespace capaLogica
{
    public class cCompra
    {
        string idCompra;
        string idProveedor;
        DateTime fecha;
        decimal total;

        public cCompra() { }

        public cCompra(string idCompra, string idProveedor, DateTime fecha, decimal total)
        {
            this.idCompra = idCompra;
            this.idProveedor = idProveedor;
            this.fecha = fecha;
            this.total = total;
        }

        public string IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }
        public string IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool insertar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspInsertarCompra", idCompra, idProveedor, fecha, total);
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
                DataRow ofila = oDatos.TraerDataRow("uspActualizarCompra", idCompra, idProveedor, fecha, total);
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
                DataRow ofila = oDatos.TraerDataRow("uspEliminarCompra", idCompra);
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
            return oDatos.TraerDataTable("uspListarCompra");
        }
    }
}
