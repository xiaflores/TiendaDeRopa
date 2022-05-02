using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaControlador
{
    public class CProveedor
    {
        public static string Insertar(string pro_num_doc,string nombre, string direccion, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();
            Obj.Pro_Num_Doc = pro_num_doc;
            Obj.Nombre = nombre;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int idproveedor,string pro_num_doc, string nombre,string direccion, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();
            Obj.Id_Proveedor = idproveedor;
            Obj.Pro_Num_Doc = pro_num_doc;
            Obj.Nombre = nombre;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Id_Proveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
