using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace capaLogica
{
    internal class cCliente
    {
        // Propiedades
        public string IdCliente { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Constructor que inicializa todas las propiedades
        public cCliente(string idCliente, string dni, string nombre, string correo, string telefono, bool estado, DateTime fechaRegistro)
        {
            IdCliente = idCliente;
            DNI = dni;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Estado = estado;
            FechaRegistro = fechaRegistro;
        }

        // Constructor por defecto
        public cCliente() { }

        // Método para obtener una representación en cadena del objeto
        public override string ToString()
        {
            return $"ID: {IdCliente}, DNI: {DNI}, Nombre: {Nombre}, Correo: {Correo}, Teléfono: {Telefono}, Estado: {Estado}, Fecha de Registro: {FechaRegistro.ToShortDateString()}";
        }
    }
}