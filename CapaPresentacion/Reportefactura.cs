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
    public partial class Reportefactura : Form
    {
        private int _Idventa;

        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }
        public Reportefactura()
        {
            InitializeComponent();
        }

        private void Reportefactura_Load(object sender, EventArgs e)
        {
            LsyarDFactura();
        }

        private void LsyarDFactura()
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetReportes.reporte_factura' Puede moverla o quitarla según sea necesario.
            this.reporte_facturaTableAdapter.Fill(this.DataSetReportes.reporte_factura, Idventa);

            this.reportViewer1.RefreshReport();
        }
    }
}
