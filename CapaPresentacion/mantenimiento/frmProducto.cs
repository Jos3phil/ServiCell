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
namespace appFormularios_Proyecto
{
    public partial class frmProducto : Form
    {
        cCategoria oCategoria = new cCategoria();
        
        public frmProducto()
        {
            InitializeComponent();
            llenarcomboCateogia();
            
        }
        public void llenarcomboCateogia()
        {
            DataTable dt = oCategoria.Listar();
            HashSet<string> nombresUnicos = new HashSet<string>();

            foreach (DataRow row in dt.Rows)
            {
                string nombre = row["Descripción"].ToString();
                if (!nombresUnicos.Contains(nombre))
                {
                    nombresUnicos.Add(nombre);
                }
            }

            cboCategoria.Items.Clear();
            foreach (string nombre in nombresUnicos)
            {
                cboCategoria.Items.Add(nombre);
            }
        }


        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }
    }
}
