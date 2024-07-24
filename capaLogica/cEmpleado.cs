using capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    internal class cEmpleado
    {
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string IdRol { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }

        cDatos oDatos = new cDatosSQL();
        public string Mensaje { get; set; }

        public cEmpleado(string idEmpleado, string nombre, string dni, string correo, string telefono, string idRol, string nombreusuario,string contraseña, DateTime fechaRegistro)
        {
            IdEmpleado = idEmpleado;
            Nombre = nombre;
            DNI = dni;
            Correo = correo;
            Telefono = telefono;
            IdRol = idRol;
            NombreUsuario =  nombreusuario;
            Contraseña = contraseña;
            FechaRegistro = fechaRegistro;
        }

    }

}
