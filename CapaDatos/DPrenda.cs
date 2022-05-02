using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DPrenda
    {
        private int _Idprenda;
        private string _Nombre;       
        private byte[] _Imagen;
        private string _Talla;
        private string _Color;
        private string _Marca;

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        

        public string Talla
        {
            get { return _Talla; }
            set { _Talla = value; }
        }
        private string _TextoBuscar;

        public int Idprenda
        {
            get { return _Idprenda; }
            set { _Idprenda = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        public DPrenda()
        {

        }

        public DPrenda(int idprenda, string nombre, string marca, string color, string talla, byte[] imagen, string textobuscar)
        {
            this.Idprenda = idprenda;
            this.Nombre = nombre;
            this.Marca = marca;
            this.Color = color;
            this.Talla = talla;
            this.Imagen = imagen;
            this.TextoBuscar = textobuscar;
        }
        public string Insertar(DPrenda Prenda)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_prenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdprenda = new SqlParameter();
                ParIdprenda.ParameterName = "@idprenda";
                ParIdprenda.SqlDbType = SqlDbType.Int;
                ParIdprenda.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdprenda);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Prenda.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Prenda.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParColor = new SqlParameter();
                ParColor.ParameterName = "@color";
                ParColor.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 30;
                ParColor.Value = Prenda.Color;
                SqlCmd.Parameters.Add(ParColor);

                SqlParameter ParTalla = new SqlParameter();
                ParTalla.ParameterName = "@talla";
                ParTalla.SqlDbType = SqlDbType.VarChar;
                ParTalla.Size = 5;
                ParTalla.Value = Prenda.Talla;
                SqlCmd.Parameters.Add(ParTalla);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Prenda.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


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
        public string Editar(DPrenda Prenda)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_prenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdprenda = new SqlParameter();
                ParIdprenda.ParameterName = "@idprenda";
                ParIdprenda.SqlDbType = SqlDbType.Int;
                ParIdprenda.Value = Prenda.Idprenda;
                SqlCmd.Parameters.Add(ParIdprenda);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Prenda.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Prenda.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParColor = new SqlParameter();
                ParColor.ParameterName = "@color";
                ParColor.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 30;
                ParColor.Value = Prenda.Color;
                SqlCmd.Parameters.Add(ParColor);

                SqlParameter ParTalla = new SqlParameter();
                ParTalla.ParameterName = "@talla";
                ParTalla.SqlDbType = SqlDbType.VarChar;
                ParTalla.Size = 5;
                ParTalla.Value = Prenda.Talla;
                SqlCmd.Parameters.Add(ParTalla);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Prenda.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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
        public string Eliminar(DPrenda Prenda)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_prenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdprenda = new SqlParameter();
                ParIdprenda.ParameterName = "@idprenda";
                ParIdprenda.SqlDbType = SqlDbType.Int;
                ParIdprenda.Value = Prenda.Idprenda;
                SqlCmd.Parameters.Add(ParIdprenda);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


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
            DataTable DtResultado = new DataTable("prenda");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_prenda";
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
        public DataTable BuscarNombre(DPrenda Prenda)
        {
            DataTable DtResultado = new DataTable("prenda");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_prenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Prenda.TextoBuscar;
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
