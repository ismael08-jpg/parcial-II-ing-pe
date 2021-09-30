using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial_II_ing_pe.Vistas
{
    public partial class FrmDetalleFactura : Form
    {
        exam2DSEntities contexto = new exam2DSEntities();

        public void fillComboProd()
        {
            comboCodProd.DataSource = null;
            comboCodProd.DataSource = contexto.producto.ToList();
            comboCodProd.DisplayMember = "nomProd";
            comboCodProd.ValueMember = "codProd";
        }

        public void updateDatagrid()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = contexto.producto.ToList();

        }
        public FrmDetalleFactura()
        {
            InitializeComponent();
            fillComboProd();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
