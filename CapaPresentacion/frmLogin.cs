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
    public partial class frmLogin : Form
    {
        public string password;
        public frmLogin()
        {
            InitializeComponent();
            LblHora.Text = DateTime.Now.ToString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            
            password = txtPassword.Text;
            string hash = CapaPresentacion.frmTrabajador.Seguridad.Encriptar(txtPassword.Text);
            txtPassword.Text = hash;
            password = txtPassword.Text;
            DataTable Datos = CapaControlador.Ctrabajador.Login(this.txtUsuario.Text, this.txtPassword.Text);
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("No Tiene Acceso al Sistema", "Tienda de Ropa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmPrincipal frm = new frmPrincipal();
                frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();

            }
        }

        private void txtPassword_Enter_1(object sender, EventArgs e)
        {
            if(txtPassword.Text=="Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="Usuario")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="")
            {
                txtUsuario.Text = "Usuario";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
