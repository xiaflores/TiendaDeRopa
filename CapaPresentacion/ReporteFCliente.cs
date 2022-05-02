using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ReporteFCliente : Form
    {
        public ReporteFCliente()
        {
            InitializeComponent();
        }

        private void ReporteFCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetReportes.spmostrar_cliente' Puede moverla o quitarla según sea necesario.
            this.spmostrar_clienteTableAdapter.Fill(this.DataSetReportes.spmostrar_cliente);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
