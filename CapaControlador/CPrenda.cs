using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaControlador
{
    public class CPrenda
    {
        public static string Insertar(string nombre,string marca,string color,string talla, byte[] imagen)
        {
            DPrenda Obj = new DPrenda();
            Obj.Nombre = nombre;
            Obj.Marca = marca;
            Obj.Color = color;
            Obj.Talla = talla;
            Obj.Imagen = imagen;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int idprenda,string nombre ,string marca, string color,string talla,byte[] imagen)
        {
            DPrenda Obj = new DPrenda();
            Obj.Idprenda = idprenda;
            Obj.Nombre = nombre;
            Obj.Marca = marca;
            Obj.Color = color;
            Obj.Talla = talla;
            Obj.Imagen = imagen;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idprenda)
        {
            DPrenda Obj = new DPrenda();
            Obj.Idprenda = idprenda;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DPrenda().Mostrar();
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPrenda Obj = new DPrenda();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
