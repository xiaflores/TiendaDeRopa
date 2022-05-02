using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaControlador
{
    public class CIngreso
    {
        public static string Insertar(int id_trabajdor, int id_proveedor,
            string tipo_comprobante,string num_comprobante, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Id_Trabajador = id_trabajdor;
            Obj.Id_Proveedor = id_proveedor;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Num_Coprobante = num_comprobante;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idprenda = Convert.ToInt32(row["idprenda"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
