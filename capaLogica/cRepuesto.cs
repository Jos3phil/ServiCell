using capaDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    public class cRepuesto
    {
        string idRepuesto;
        string idMarca;
        string modelo;
        string idCategoria;
        string color;
        int stock;
        decimal precioCompra;
        decimal precioVenta;
        DateTime fechaRegistro;

        public cRepuesto() { }

        public cRepuesto(string idRepuesto, string idMarca, string modelo, string idCategoria, string color, int stock, decimal precioCompra, decimal precioVenta, DateTime fechaRegistro)
        {
            this.idRepuesto = idRepuesto;
            this.idMarca = idMarca;
            this.modelo = modelo;
            this.idCategoria = idCategoria;
            this.color = color;
            this.stock = stock;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.fechaRegistro = fechaRegistro;
        }

        public string IdRepuesto
        {
            get { return idRepuesto; }
            set { idRepuesto = value; }
        }

        public string IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public decimal PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }

        public decimal PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool Insertar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspInsertarRepuesto", idRepuesto, idMarca, modelo, idCategoria, color, stock, precioCompra, precioVenta, fechaRegistro);
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

        public bool Modificar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspActualizarRepuesto", idRepuesto, idMarca, modelo, idCategoria, color, stock, precioCompra, precioVenta, fechaRegistro);
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

        public bool Eliminar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspEliminarRepuesto", idRepuesto);
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

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("uspListarRepuestos");
        }

        public DataTable Buscar(string campo, string valor)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT * FROM Repuesto WHERE {campo} LIKE '%{valor}%'";

            string connectionString = ConfigurationManager.ConnectionStrings["Cadena"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("La cadena de conexión 'Cadena' no está definida en el archivo de configuración.");
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
