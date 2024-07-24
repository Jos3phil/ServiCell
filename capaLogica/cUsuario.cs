using capaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;  // sqlComand y sqlParameter
using System.Configuration;

namespace capaLogica
{
    public class cUsuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string IdEmpleado { get; set; }
        public string Mensaje { get; set; }

        cDatos oDatos = new cDatosSQL();

        // Constructor por defecto
        public cUsuario() { }

        // Constructor con parámetros
        public cUsuario(string idUsuario, string nombreUsuario, string contraseña, string idEmpleado)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            IdEmpleado = idEmpleado;
        }
        
        public bool ValidarDatos()
        {
            try
            {
                DataRow ofila = oDatos.TraerDataRow("ValidarUsuarioContrasena", NombreUsuario, Contraseña);
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
        public string EncriptarClave(string clave)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(clave);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString(0,20);
            }
        }
    }
}
