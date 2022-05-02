using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaControlador;
namespace CapaPresentacion
{
    public partial class frmVistaPrenda_Venta : Form
    {
        public frmVistaPrenda_Venta()
        {
            InitializeComponent();
        }

        private void frmVistaPrenda_Venta_Load(object sender, EventArgs e)
        {
            this.MostrarPrenda_Venta_Nombre();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void MostrarPrenda_Venta_Nombre()
        {
            this.dataListado.DataSource = CVenta.MostrarPrenda_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource = CPrenda.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.MostrarPrenda_Venta_Nombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            decimal par3, par4;
            int par5;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["stock_actual"].Value);
            form.setArticulo(par1, par2, par3, par4, par5);
            this.Hide();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
