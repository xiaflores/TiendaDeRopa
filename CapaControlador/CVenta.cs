using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaControlador
{
    public class CVenta
    {
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha,string factura,DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.Idcliente = idcliente;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Factura = factura;
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarPrenda_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarPrenda_Venta_Nombre(textobuscar);
        }
    }
}
