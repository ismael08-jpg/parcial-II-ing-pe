using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using parcial_II_ing_pe.Vistas;

namespace parcial_II_ing_pe
{
    public partial class FrmMain : Form
    {
        

        public FrmMain()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detalleDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetalleFactura formDF = new FrmDetalleFactura();
            formDF.MdiParent = this;

            formDF.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
