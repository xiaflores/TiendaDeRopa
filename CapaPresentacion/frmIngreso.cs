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
    public partial class frmIngreso : Form
    {
        public int Idtrabajdor;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        private static frmIngreso _instancia;

        public static frmIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmIngreso();
            }
            return _instancia;
        }
        public void setProveedor(string idproveedor, string nombre)
        {
            this.txtId_proveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }

        public void setPrenda(string idprenda, string descripcion)
        {
            this.txtIdarticulo.Text = idprenda;
            this.txtArticulo.Text = descripcion;
        }
        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el Proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Comprobante, "Ingrese el número del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione la Prenda de compra");
            this.txtId_proveedor.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;

        }
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
            this.txtIdingreso.Text = string.Empty;
            this.txtId_proveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtNum_Comprobante.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtIdingreso.ReadOnly = !valor;
            this.txtNum_Comprobante.ReadOnly = !valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;
            this.btnBuscarPrenda.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
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
            this.dataListado.DataSource = CIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = CIngreso.MostrarDetalle(this.txtIdingreso.Text);

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idprenda", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("prenda", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }


        private void frmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso vista = new frmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscarPrenda_Click(object sender, EventArgs e)
        {
            frmVistaPrenda_Ingreso vista = new frmVistaPrenda_Ingreso();
            vista.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.limpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtId_proveedor.Text == string.Empty || this.txtNum_Comprobante.Text == string.Empty || dataListadoDetalle.RowCount==0 )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtId_proveedor, "Ingrese un Valor");
                    errorIcono.SetError(dataListadoDetalle, "El detalle de los ingresis esta Vacio");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = CIngreso.Insertar(Idtrabajdor,Convert.ToInt32(txtId_proveedor.Text), cbTipo_Comprobante.Text, txtNum_Comprobante.Text, dtDetalle);
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

                if (this.txtIdarticulo.Text == string.Empty || this.txtStock.Text == string.Empty
                    || this.txtPrecio_Compra.Text == string.Empty || this.txtPrecio_Venta.Text == string.Empty||this.txtNum_Comprobante.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Compra, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Comprobante, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idprenda"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }   
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.0#");
                        DataRow row = this.dtDetalle.NewRow();
                        row["idprenda"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["prenda"] = this.txtArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

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

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdingreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idingreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtNum_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_comprobante"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
