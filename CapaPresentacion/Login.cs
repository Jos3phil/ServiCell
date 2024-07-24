using formulario_principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaLogica;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        private cUsuario ousuario = new cUsuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ousuario.NombreUsuario = txtusuario.Text;
            ousuario.Contraseña = txtcontraseña.Text;
            if (ousuario.ValidarDatos())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //((FormPrincipal)MdiParent).DeshabilitarMenu();
            txtusuario.Focus();
            //timer1.Enabled = true;
            //lblTiempo.Text = tiempo.ToString();
        }
    }
}
