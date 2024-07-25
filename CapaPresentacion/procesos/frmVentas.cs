using capaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.procesos
{
    public partial class frmVentas : Form
    {
        cVenta oVenta = new cVenta();
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarVenta_Click(object sender, EventArgs e)
        {
            try
            {// Verificar que se ha seleccionado un tipo de documento
                if (cmbTipoDocumento.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de documento.");
                    return ;
                }

                // Asignar los valores de los controles a la instancia existente de cVenta
                oVenta.IdVenta = Guid.NewGuid().ToString(); // Generar un nuevo ID para la venta
                oVenta.IdEmpleado = "E00002"; // Asigna el ID del empleado (puedes cambiar esto según tu lógica)
                oVenta.TipoDocumento = cmbTipoDocumento.SelectedItem.ToString();
                oVenta.NumeroDocumento = txtDNICliente.Text;
                oVenta.IdCliente = "C00001";
                oVenta.MontoPago = Convert.ToDecimal(txtPagacon.Text);
                oVenta.MontoCambio = Convert.ToDecimal(txtCambio.Text);
                oVenta.MontoTotal = Convert.ToDecimal(txtTotal.Text);
                oVenta.FechaIngreso = dateahora.Value;

                // Insertar la venta utilizando el método insertar de cVenta
                if (oVenta.insertar())
                {
                    MessageBox.Show("Venta insertada correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al insertar la venta: " + oVenta.Mensaje);
                }

                // Iniciar el timer y actualizar la lista de ventas
                //timer1.Start();
                // listar();*/
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // configuracionInicial();
        }
    }
}
