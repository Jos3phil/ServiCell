using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capaDatos;

namespace capaLogica
{
    public class cDetalleVenta
    {
        string idDetalleVenta;
        string idVenta;
        string idProducto;
        int cantidad;
        decimal precio;

        public cDetalleVenta() { }

        public cDetalleVenta(string idDetalleVenta, string idVenta, string idProducto, int cantidad, decimal precio)
        {
            this.idDetalleVenta = idDetalleVenta;
            this.idVenta = idVenta;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public string IdDetalleVenta
        {
            get { return idDetalleVenta; }
            set { idDetalleVenta = value; }
        }
        public string IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }
        public string IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool insertar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspInsertarDetalleVenta", idDetalleVenta, idVenta, idProducto, cantidad, precio);
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
                DataRow ofila = oDatos.TraerDataRow("uspActualizarDetalleVenta", idDetalleVenta, idVenta, idProducto, cantidad, precio);
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
                DataRow ofila = oDatos.TraerDataRow("uspEliminarDetalleVenta", idDetalleVenta);
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
            return oDatos.TraerDataTable("uspListarDetalleVenta");
        }
    }
}

