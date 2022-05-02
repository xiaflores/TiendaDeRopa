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
    public partial class ReportePrenadas : Form
    {
        public ReportePrenadas()
        {
            InitializeComponent();
        }

        private void ReportePrenadas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetReportes.SpmostrarPrendas' Puede moverla o quitarla según sea necesario.
            this.SpmostrarPrendasTableAdapter.Fill(this.DataSetReportes.SpmostrarPrendas);
            // TODO: esta línea de código carga datos en la tabla 'DataSetReportes.spmostrar_proveedor' Puede moverla o quitarla según sea necesario.
            this.spmostrar_proveedorTableAdapter.Fill(this.DataSetReportes.spmostrar_proveedor);
            // TODO: esta línea de código carga datos en la tabla 'DataSetReportes.spmostrar_prenda' Puede moverla o quitarla según sea necesario.
            this.spmostrar_prendaTableAdapter.Fill(this.DataSetReportes.spmostrar_prenda);

            this.reportViewer1.RefreshReport();
        }
    }
}
