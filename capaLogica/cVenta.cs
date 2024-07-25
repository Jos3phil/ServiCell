using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capaDatos;

namespace capaLogica
{
    public class cVenta
    {
        private cDatos oDatos = new cDatosSQL();
        public string IdVenta { get; set; }
        public string IdEmpleado { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string IdCliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Mensaje { get; private set; }

        public cVenta() { }

        public cVenta(string idVenta, string idEmpleado, string tipoDocumento, string numeroDocumento, string idCliente, decimal montoPago, decimal montoCambio, decimal montoTotal, DateTime fechaIngreso)
        {
            IdVenta = idVenta;
            IdEmpleado = idEmpleado;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            IdCliente = idCliente;
            MontoPago = montoPago;
            MontoCambio = montoCambio;
            MontoTotal = montoTotal;
            FechaIngreso = fechaIngreso;
        }





        public bool insertar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("InsertarVenta", IdVenta, IdEmpleado, TipoDocumento, NumeroDocumento, IdCliente, MontoPago, MontoCambio, MontoTotal, FechaIngreso);
                Mensaje = ofila["Mensaje"].ToString();
                byte codError = Convert.ToByte(ofila["CodError"]);
                return codError == 0;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        /*
        public bool modificar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspActualizarVenta", idVenta, idCliente, fecha, total);
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
                DataRow ofila = oDatos.TraerDataRow("uspEliminarVenta", idVenta);
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
            return oDatos.TraerDataTable("uspListarVenta");
        }*/
    }
}
