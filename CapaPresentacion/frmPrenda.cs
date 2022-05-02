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
    public partial class frmPrenda : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static frmPrenda _Instancia;

        public static frmPrenda GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmPrenda();
            }
            return _Instancia;
        }
        public void setCategoria(string idcategoria, string nombre)
        {
             
        }
        public frmPrenda()
        {
            InitializeComponent();
            //this.ttMensaje.SetToolTip(this.txtColor, "Ingrese el Color de la Prenda");
            //this.ttMensaje.SetToolTip(this.txtMarca, "Ingrese La Marca de la Prenda");
            //this.ttMensaje.SetToolTip(this.txtTalla, "Ingrese la Talla de la Prenda");
            //this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la Imagen de la Prenda");
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Tienda De Ropa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Tienda De Ropa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //private void Limpiar()
        //{
        //    this.txtMarca.Text = string.Empty;
        //    this.txtNombre.Text = string.Empty;
        //    this.txtIdPrenda.Text = string.Empty;
        //    this.txtColor.Text = string.Empty;
        //    this.txtTalla.Text = string.Empty;
        //    this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.foto;
        //}
        //private void Habilitar(bool valor)
        //{
        //    this.txtMarca.ReadOnly = !valor;
        //    this.txtNombre.ReadOnly = !valor;
        //    this.txtColor.ReadOnly = !valor;
        //    this.btnCargar.Enabled = valor;
        //    this.btnLimpiar.Enabled = valor;
        //    this.txtIdPrenda.ReadOnly = !valor;
        //}
        //private void Botones()
        //{
        //    if (this.IsNuevo || this.IsEditar)
        //    {
        //        this.Habilitar(true);
        //        this.btnNuevo.Enabled = false;
        //        this.btnGuardar.Enabled = true;
        //        this.btnEditar.Enabled = false;
        //        this.btnCancelar.Enabled = true;
        //    }
        //    else
        //    {
        //        this.Habilitar(false);
        //        this.btnNuevo.Enabled = true;
        //        this.btnGuardar.Enabled = false;
        //        this.btnEditar.Enabled = true;
        //        this.btnCancelar.Enabled = false;
        //    }

        //}
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = CPrenda.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource = CPrenda.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void frmPrenda_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            //this.Habilitar(false);
           // this.Botones();
           dataListado.ClearSelection();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
              //  this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.imagen;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            //this.Botones();
            //this.Limpiar();
            //this.Habilitar(true);
            //this.txtMarca.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*try
            {
                string rpta = "";
                if (this.txtMarca.Text == string.Empty )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        rpta = CPrenda.Insertar(this.txtNombre.Text.Trim().ToUpper(),this.txtMarca.Text.Trim().ToUpper(), this.txtColor.Text.Trim().ToUpper(), this.txtTalla.Text.Trim().ToUpper(), imagen);

                    }
                    else
                    {
                        rpta = CPrenda.Editar(Convert.ToInt32(this.txtIdPrenda.Text),this.txtNombre.Text.Trim().ToUpper(), this.txtMarca.Text.Trim().ToUpper(), this.txtColor.Text.Trim().ToUpper(), this.txtTalla.Text.Trim().ToUpper(), imagen);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }*/
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //if (!this.txtIdPrenda.Text.Equals(""))
            //{
            //    this.IsEditar = true;
            //    this.Botones();
            //    this.Habilitar(true);
            //}
            //else
            //{
            //    this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.IsNuevo = false;
            //this.IsEditar = false;
            //this.Botones();
            //this.Limpiar();
            //this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //this.txtIdPrenda.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idprenda"].Value);
            //this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            //this.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
            //this.txtColor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["color"].Value);
            //this.txtTalla.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["talla"].Value);
            //byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;

            //System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            //this.pxImagen.Image = Image.FromStream(ms);
            //this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.tabControl1.SelectedIndex = 1;

            frmPrendaDatos frm = new frmPrendaDatos();
            frm.txtIdPrenda.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idprenda"].Value);
            frm.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            frm.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
            frm.txtColor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["color"].Value);
            frm.txtTalla.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["talla"].Value);
            frm.ShowDialog();

            //byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;

            //System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            //frm.pxImage.Image = Image.FromStream(ms);
            //frm.pxImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = CPrenda.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void imagen_ClientSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void dataListado_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void frmPrenda_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_RowHeaderCellChanged(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void dataListado_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pictureBox3.Image = Image.FromStream(ms);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataListado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            //System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            //this.pictureBox3.Image = Image.FromStream(ms);
        }

        private void dataListado_CurrentCellChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            frmPrendaDatos frm = new frmPrendaDatos();
        }
    }
}
