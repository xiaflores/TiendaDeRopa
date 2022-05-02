using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;

        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";

        public frmPrincipal()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MnuSalir_Click(object sender, EventArgs e)
        {

        }

        private void prendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrenda frm = new frmPrenda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ingresosAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GestionUsuario()
        {
            if (Acceso == "Administrador")
            {
                this.toolStripMenuItem2.Enabled = true;
                this.MnuVentas.Enabled = true;
                this.almacenmenu.Enabled = true;
                this.Mnusalir.Enabled = true;
                this.menuSalir.Enabled = true;

            }
            else if (Acceso == "Cajero")
            {
                this.toolStripMenuItem2.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.mnualmacen.Enabled = false;
                this.almacenmenu.Enabled = true;
            }
            else
            {
                this.toolStripMenuItem2.Enabled = false;
                this.MnuVentas.Enabled = false;
                this.almacenmenu.Enabled = false;
                this.Mnusalir.Enabled = false;
                this.menuSalir.Enabled = false;
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador =Convert.ToInt32(this.Idtrabajador);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void MnuVentas_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pRENDASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPrenda frm = frmPrenda.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mnualmacen_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajdor=Convert.ToInt32(this.Idtrabajador);
        }
        private void ReportePrendas_Click(object sender, EventArgs e)
        {
            ReportePrenadas frm = new ReportePrenadas();
            frm.ShowDialog();
        }
        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cerrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //labe1.Text = DateTime.Now.ToString();
        }

        private void prendasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ReportePrenadas frm = new ReportePrenadas();
            frm.ShowDialog();
        }

        private void personalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteTrabajador frm = new frmReporteTrabajador();
            frm.ShowDialog();
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReporteFProveedores frm = new ReporteFProveedores();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReporteFCliente frm = new ReporteFCliente();
            frm.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteFIngreso frm = new ReporteFIngreso();
            frm.ShowDialog();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteFVentas frm = new ReporteFVentas();
            frm.ShowDialog();
        }

        private void listadoventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteFVentas frm = new ReporteFVentas();
            frm.ShowDialog();
        }

        private void almacenmenu_Click(object sender, EventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string ruta = @"D:\carrera\Diseño de Siatemas\PROYECTO\Proyecto_Diseño_Sistemas\CapaPresentacion\ayuda.html";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}