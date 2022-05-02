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
    public partial class frmVenta : Form
    {
        private bool IsNuevo = false;
        private static frmVenta _instancia;

        public static frmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setArticulo(string iddetalle_ingreso, string nombre,
            decimal precio_compra, decimal precio_venta, int stock)
        {
            this.txtIdprenda.Text = iddetalle_ingreso;
            this.txtPrenda.Text = nombre;
            this.txtPrecio_Compra.Text = Convert.ToString(precio_compra);
            this.txtPrecio_Venta.Text = Convert.ToString(precio_venta);
            this.txtStock_Actual.Text = Convert.ToString(stock);
        }
        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la Cantidad de Prendas a Vender");
            this.ttMensaje.SetToolTip(this.txtPrenda, "Seleccione la Prenda");
            this.txtIdcliente.Visible = false;
            this.txtIdprenda.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtPrenda.ReadOnly = true;
            this.txtPrecio_Compra.ReadOnly = true;
            this.txtStock_Actual.ReadOnly = true;
        }
        public int Idtrabajador;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Tienda de Ropa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Tienda de Ropa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtFactura.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtIdprenda.Text = string.Empty;
            this.txtPrenda.Text = string.Empty;
            this.txtStock_Actual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
        }
        private void generar_factura()
        {
            int f1, f2;
            Random aleatorio = new Random();
            double r1 = Convert.ToDouble(aleatorio.NextDouble());
            f1 = Convert.ToInt32(1000 * r1);
            double r2 = Convert.ToDouble(aleatorio.NextDouble());
            f2 = Convert.ToInt32(100000 * r2);
            txtFactura.Text = "000"+Convert.ToString(f1) + Convert.ToString(f2);

        }
        private void Habilitar(bool valor)
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtFactura.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;
            this.txtStock_Actual.ReadOnly = !valor;
            this.btnBuscarPrenda.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.btnFacturaEnviar.Enabled = valor;
        }
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
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
            this.dataListado.DataSource = CVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = CVenta.MostrarDetalle(this.txtIdventa.Text);

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("prenda", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente_Venta vista = new frmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void btnBuscarPrenda_Click(object sender, EventArgs e)
        {
            frmVistaPrenda_Venta frm = new frmVistaPrenda_Venta();
            frm.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.generar_factura();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Teinda de Ropa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = CVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente la venta");
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.txtFactura.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["factura"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtFactura.Text == string.Empty || dataListadoDetalle.RowCount==0)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(dataListadoDetalle, "El detalle de la venta esta vacio");

                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = CVenta.Insertar(Convert.ToInt32(this.txtIdcliente.Text), Idtrabajador,
                        dtFecha.Value, txtFactura.Text, dtDetalle);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdprenda.Text == string.Empty || this.txtCantidad.Text == string.Empty || this.txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdprenda, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdprenda.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock_Actual.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdprenda.Text);
                        row["prenda"] = this.txtPrenda.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay Stock Suficiente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text = totalPagado.ToString("#0.0#");
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dataListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            Reportefactura form = new Reportefactura();
            form.Idventa = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idventa"].Value);
            form.ShowDialog();
        }

        private void btnFacturaEnviar_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
