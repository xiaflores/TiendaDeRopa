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
    public partial class ReporteFIngreso : Form
    {
        public ReporteFIngreso()
        {
            InitializeComponent();
        }

        private void ReporteIngreso_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetReportes.spmostrar_ingreso' Puede moverla o quitarla según sea necesario.
            this.spmostrar_ingresoTableAdapter.Fill(this.DataSetReportes.spmostrar_ingreso);

            this.reportViewer1.RefreshReport();
        }
    }
}
