using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capaDatos;

namespace capaLogica
{
    public class cDetalleCompra
    {
        string idDetalleCompra;
        string idCompra;
        string idProducto;
        int cantidad;
        decimal precio;

        public cDetalleCompra() { }

        public cDetalleCompra(string idDetalleCompra, string idCompra, string idProducto, int cantidad, decimal precio)
        {
            this.idDetalleCompra = idDetalleCompra;
            this.idCompra = idCompra;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public string IdDetalleCompra
        {
            get { return idDetalleCompra; }
            set { idDetalleCompra = value; }
        }
        public string IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
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
                DataRow ofila = oDatos.TraerDataRow("uspInsertarDetalleCompra", idDetalleCompra, idCompra, idProducto, cantidad, precio);
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
                DataRow ofila = oDatos.TraerDataRow("uspActualizarDetalleCompra", idDetalleCompra, idCompra, idProducto, cantidad, precio);
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
                DataRow ofila = oDatos.TraerDataRow("uspEliminarDetalleCompra", idDetalleCompra);
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
            return oDatos.TraerDataTable("uspListarDetalleCompra");
        }
    }
}
