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
    public partial class frmVistaProveedor_Ingreso : Form
    {
        public frmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }

        private void frmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = CProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = CProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNum_Documento();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNum_Documento();
        }


        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setProveedor(par1, par2);
            this.Hide();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
