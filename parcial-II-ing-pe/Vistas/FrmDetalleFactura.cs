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


        public void fillDatagrid()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = contexto.detalle_factura.ToList();
        }
        public FrmDetalleFactura()
        {
            InitializeComponent();
            fillComboProd();
            fillDatagrid();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            detalle_factura det_fac = new detalle_factura();

            det_fac.correlativo = int.Parse(txtCorrelativo.Text);
            det_fac.codProd = int.Parse(comboCodProd.SelectedValue.ToString());
            det_fac.cant = int.Parse(numCantidad.Text);

            //Persist

            contexto.detalle_factura.Add(det_fac);
            if (contexto.SaveChanges() == 1)
            {
                MessageBox.Show("¡Factura Creada Exitosamente!");

            }


            //actualziar el grid
            fillDatagrid();

            //limpiar las cajas de texto
            clear();
        }

        private void clear()
        {
            txtCorrelativo.Clear();
            comboCodProd.SelectedIndex = -1; //Items.Clear()
            numCantidad.ResetText();   
        }
    }
}
