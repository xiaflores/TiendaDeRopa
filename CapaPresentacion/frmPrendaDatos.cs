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
    public partial class frmPrendaDatos : Form
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

        public frmPrendaDatos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtMarca.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtIdPrenda.Text = string.Empty;
            this.txtColor.Text = string.Empty;
            this.txtTalla.Text = string.Empty;
            this.pxImage.Image = global::CapaPresentacion.Properties.Resources.foto;
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Tienda De Ropa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Tienda De Ropa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtMarca.Text == string.Empty )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

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
                    //this.Botones();
                    //this.Limpiar();
                    //this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
