using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaControlador
{
    public class Ctrabajador
    {
        public static string Insertar(string num_documento,string nombre, string apellidos, string direccion, string sexo, DateTime fecha_nacimiento, string telefono, string email, string acceso,
            string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Num_Documento = num_documento;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Direccion = direccion;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int idtrabajador,string num_documento, string nombre, string apellidos, string direccion, string sexo, DateTime fecha_nacimiento, string telefono, string email, string acceso, string usuario,
            string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Num_Documento = num_documento;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Direccion = direccion;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }

        public static DataTable Login(string usuario,string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}