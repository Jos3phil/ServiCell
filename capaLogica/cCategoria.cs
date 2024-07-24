using capaDatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    public class cCategoria
    {
        // Propiedades que representan las columnas de la tabla Categoría
        public string IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } 

        public string Mensaje;

        // Constructor sin parámetros
        public cCategoria()
        {
        }
        cDatos oDatos = new cDatosSQL();
        // Constructor con parámetros
        public cCategoria(string idCategoria, string descripcion, DateTime fechaRegistro)
        {
            IdCategoria = idCategoria;
            Descripcion = descripcion;
            FechaRegistro = fechaRegistro;
        }

        // Método para representar el objeto como una cadena (opcional)
        public override string ToString()
        {
            return $"ID: {IdCategoria}, Descripción: {Descripcion}, Fecha de Registro: {FechaRegistro.ToShortDateString()}";
        }
        public bool Insertar()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("uspInsertarCategoria", IdCategoria,Descripcion,FechaRegistro);
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
            return oDatos.TraerDataTable("uspListarCategorias");
        }
    }
}
