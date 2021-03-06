using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace parcial_II_ing_pe.Vistas
{
    public partial class FrmDetalleFactura : Form
    {
        exam2DSEntities contexto = new exam2DSEntities();
        private BindingSource src = new BindingSource();

        public void fillComboProd()
        {
            comboCodProd.DataSource = null;
            comboCodProd.DataSource = contexto.producto.ToList();
            comboCodProd.DisplayMember = "nomProd";
            comboCodProd.ValueMember = "codProd";
        }

        public void fillDatagrid()
        {
            detalle_factura dt = new detalle_factura();
            var detalleFactura = contexto.detalle_factura.ToList();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = detalleFactura;
            guna2DataGridView1.Columns["Producto"].Visible = false;
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

            try
            {
                det_fac.correlativo = int.Parse(txtCorrelativo.Text);
                det_fac.codProd = int.Parse(comboCodProd.SelectedValue.ToString());
                det_fac.cant = int.Parse(numCantidad.Text);

                //Persist

                contexto.detalle_factura.Add(det_fac);
                if (contexto.SaveChanges() == 1)
                {
                    MessageBox.Show("¡Factura Creada Exitosamente!");
                }

                fillDatagrid(); 
                clear();
            }
            catch (Exception message)
            {
                MessageBox.Show("Hubo un error al tratar de crear la factura !" + message.ToString());
            }
        }

        private void clear()
        {
            txtCorrelativo.Clear();
            comboCodProd.SelectedIndex = -1; //Items.Clear()
            numCantidad.ResetText();   
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            producto prod = new producto();
            prod = (producto)guna2DataGridView1.CurrentRow.Cells[3].Value;

            txtCorrelativo.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboCodProd.Text = prod.nomProd;
            numCantidad.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
          
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            
      
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int correlativo = int.Parse(txtCorrelativo.Text);

                detalle_factura d = contexto.detalle_factura.FirstOrDefault(x => x.correlativo == correlativo);




                //aplicamos la modificacion al objeto temporal
                d.correlativo = int.Parse(txtCorrelativo.Text);
                d.cant = int.Parse(numCantidad.Text);
                d.codProd = int.Parse(comboCodProd.SelectedValue.ToString());

                if (contexto.SaveChanges() == 1)
                {
                    MessageBox.Show("Modificado con éxito!");
                }
            }
            catch (Exception message)
            {
                MessageBox.Show("Hubo un error " + message);
            }

            clear();
            fillDatagrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Estas seguro que desea eliminar la factura?", "No se podrá recuperar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
               
                try
                {
                    int correlativo = int.Parse(txtCorrelativo.Text);
                    detalle_factura p = contexto.detalle_factura.FirstOrDefault(t => t.correlativo == correlativo);
                    contexto.detalle_factura.Remove(p);


                    if (contexto.SaveChanges() == 1)
                    {
                        MessageBox.Show("Eliminado con éxito!");
                    }
                } catch (Exception message)
                {
                    MessageBox.Show("Hubo un error " + message);
                }

                clear();
                fillDatagrid();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
