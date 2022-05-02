using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;

using CapaControlador;
namespace CapaPresentacion
{
    public partial class frmTrabajador : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public string password;
        public frmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el Documento del Trabajdor");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Trabajdor");
            this.ttMensaje.SetToolTip(this.txtApell, "Ingrese Los Apellidos del Trabajdor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Trabajdor");
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Tienda de Ropa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Tienda de Ropa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtIdtrabajador.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApell.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

        }
        private void Habilitar(bool Valor)
        {
            this.txtIdtrabajador.ReadOnly = !Valor;
            this.txtNum_Documento.Enabled = Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.cbSexo.Enabled = Valor;
            this.dtFecha_Nacimiento.Enabled = Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.txtEmail.ReadOnly = !Valor;
            this.cbAcceso.Enabled = Valor;
            this.txtUsuario.ReadOnly = !Valor;
            this.txtPassword.ReadOnly = !Valor;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = Ctrabajador.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = Ctrabajador.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNum_Documento();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = Ctrabajador.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente el registro");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApell.Text == string.Empty || txtNum_Documento.Text == string.Empty || txtUsuario.Text == string.Empty || txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre del Trabajador");
                    errorIcono.SetError(txtApell, "Ingrese los apellidos");
                    errorIcono.SetError(txtNum_Documento, "Ingrese el numero de Documeto");
                    errorIcono.SetError(txtUsuario, "Ingrese un Nombre de Usuario");
                    errorIcono.SetError(txtPassword, "Ingrese una Contraseña");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        password = txtPassword.Text;
                        string hash = Seguridad.Encriptar(password);
                        txtPassword.Text = hash;
                        
                        Rpta = Ctrabajador.Insertar(this.txtNum_Documento.Text.Trim().ToUpper(),this.txtNombre.Text.Trim().ToUpper(),this.txtApell.Text.Trim().ToUpper(),txtDireccion.Text,cbSexo.Text,
                        dtFecha_Nacimiento.Value, txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text,txtPassword.Text);

                    }
                    else
                    {
                        password = txtPassword.Text;
                        string hash = Seguridad.Encriptar(password);
                        txtPassword.Text = hash;
                        Rpta = Ctrabajador.Editar(Convert.ToInt32(this.txtIdtrabajador.Text), txtNum_Documento.Text,this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApell.Text.Trim().ToUpper(), txtDireccion.Text, cbSexo.Text, dtFecha_Nacimiento.Value, txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text, txtPassword.Text);
                    }
                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }

                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdtrabajador.Text = "";

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdtrabajador.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdtrabajador.Text = string.Empty;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdtrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idtrabajador"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["documento_trabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApell.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFecha_Nacimiento.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkElminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void cbAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        internal class Seguridad
        {
            public static string Encriptar(string originalPassword)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();

                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
                byte[] hash = sha1.ComputeHash(inputBytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
