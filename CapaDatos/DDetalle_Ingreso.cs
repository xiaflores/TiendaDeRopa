using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int _Iddetalle_Ingreso;
        private int _Idingreso;
        private int _Idprenda;

        private decimal _Precio_Compra;
        private decimal _Precio_Venta;

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }
        private int _Stock_Inicial;
        private int _Stock_Actual;

        public int Iddetalle_Ingreso
        {
            get { return _Iddetalle_Ingreso; }
            set { _Iddetalle_Ingreso = value; }
        }


        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }

        public int Idprenda
        {
            get { return _Idprenda; }
            set { _Idprenda = value; }
        }
        public decimal Precio_Compra
        {
            get { return _Precio_Compra; }
            set { _Precio_Compra = value; }
        }


        public int Stock_Inicial
        {
            get { return _Stock_Inicial; }
            set { _Stock_Inicial = value; }
        }


        public int Stock_Actual
        {
            get { return _Stock_Actual; }
            set { _Stock_Actual = value; }
        }
        public DDetalle_Ingreso()
        {

        }
        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso,
            int idprenda, decimal precio_compra, decimal precio_venta,
            int stock_inicial, int stock_actual)
        {
            this.Iddetalle_Ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idprenda = idprenda;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
        }
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdprenda = new SqlParameter();
                ParIdprenda.ParameterName = "@idprenda";
                ParIdprenda.SqlDbType = SqlDbType.Int;
                ParIdprenda.Value = Detalle_Ingreso.Idprenda;
                SqlCmd.Parameters.Add(ParIdprenda);


                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@precio_compra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Money;
                ParPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

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
