using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
     public class DVenta
    {
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Factura;

        public string Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }

        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public DVenta()
        {

        }
        public DVenta(int idventa, int idcliente, int idtrabajador,
            DateTime fecha, string factura)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.Factura = factura;

        }
        public string DisminuirStock(int iddetalle_ingreso, int cantidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdisminuir_stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Value = iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el stock";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Venta.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParFactura = new SqlParameter();
                ParFactura.ParameterName = "@factura";
                ParFactura.SqlDbType = SqlDbType.VarChar;
                ParFactura.Size = 15;
                ParFactura.Value = Venta.Factura;
                SqlCmd.Parameters.Add(ParFactura);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);
                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.Idventa = this.Idventa;
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            rpta = DisminuirStock(det.Iddetalle_ingreso, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }

                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }
        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        public DataTable MostrarDetalle(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable MostrarPrenda_Venta_Nombre(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("prenda");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscarprenda_venta_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
