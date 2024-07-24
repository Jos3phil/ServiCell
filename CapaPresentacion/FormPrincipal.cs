using appFormularios_Proyecto;
using CapaPresentacion;
using CapaPresentacion.procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulario_principal
{
    public partial class FormPrincipal : Form
    {
        private Dictionary<Type, Form> formulariosAbiertos = new Dictionary<Type, Form>();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFormulario(Type tipoFormulario)
        {
            if (formulariosAbiertos.ContainsKey(tipoFormulario))
            {
                Form formulario = formulariosAbiertos[tipoFormulario];
                formulario.WindowState = FormWindowState.Normal; // Restaurar si está minimizado
                formulario.BringToFront(); // Traer al frente
                formulario.Focus(); // Dar foco al formulario
            }
            else
            {
                Form formulario = (Form)Activator.CreateInstance(tipoFormulario);
                formulario.MdiParent = this; // Establecer el formulario principal como el contenedor
                formulario.StartPosition = FormStartPosition.CenterParent; // Centrar en el formulario principal
                formulario.FormClosed += (s, e) => formulariosAbiertos.Remove(tipoFormulario);
                formulario.Show();
                formulariosAbiertos.Add(tipoFormulario, formulario);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterParent; // Centrar el formulario de login sobre el principal
            frm.ShowDialog(this);
            if (frm.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                // Si el login es exitoso, cargar la barra de estado y habilitar el menú
                CargarBarraEstado();
                HabilitarMenu();
            }


        }
        public void DeshabilitarMenu()
        {
            menuStrip1.Enabled = false;
        }
        public void HabilitarMenu()
        {
            menuStrip1.Enabled = true;
        }
        public void CargarBarraEstado()
        {
            toolStripStatusLabel1.Text = Environment.UserName;//nombre de usuario 69
            toolStripStatusLabel2.Text = Environment.MachineName;//nombre de maquina 70
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString();
            toolStripStatusLabel4.Text = DateTime.Now.ToLongDateString();//fecha delsistema 72
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(typeof(Cliente));
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void iconMenuItem4_Click(object sender, EventArgs e)
        {
            //ventas
            AbrirFormulario(typeof(frmVentas));
            
        }

        private void iconMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //repuestos
            AbrirFormulario(typeof(frmProducto));
        }
    }
}
