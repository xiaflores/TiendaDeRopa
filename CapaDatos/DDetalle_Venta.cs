using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        public int Iddetalle_venta
        {
            get { return _Iddetalle_venta; }
            set { _Iddetalle_venta = value; }
        }
        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public int Iddetalle_ingreso
        {
            get { return _Iddetalle_ingreso; }
            set { _Iddetalle_ingreso = value; }
        }


        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }
        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso,
            int cantidad, decimal precio_venta)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_Venta = precio_venta;
        }
        public string Insertar(DDetalle_Venta Detalle_Venta,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Venta = new SqlParameter();
                ParIddetalle_Venta.ParameterName = "@iddetalle_venta";
                ParIddetalle_Venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_Venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = Detalle_Venta.Iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = Detalle_Venta.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
