using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaControlador
{
    public class CCliente
    {
        public static string Insertar(string documento_cliente,string nombre, string apellidos, string sexo)
        {
            DCliente Obj = CarbgarDatos(0, documento_cliente, nombre, apellidos, sexo);

            return Obj.Insertar(Obj);
        }
        public static string Editar(int idcliente, string documento_cliente, string nombre, string apellidos, string sexo)
        {
            DCliente Obj = CarbgarDatos(idcliente, documento_cliente, nombre, apellidos, sexo);

            return Obj.Editar(Obj);
        }

        private static DCliente CarbgarDatos(int idcliente, string documento_cliente, string nombre, string apellidos, string sexo)
        {
            DCliente Obj = new DCliente();
            Obj.Id_Cliente = idcliente;
            Obj.Num_Documento = documento_cliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            return Obj;
        }
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Id_Cliente = idcliente;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
