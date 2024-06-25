using KN_Web.BaseDatos;
using KN_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models
{
    public class UsuarioModel
    {
        public bool RegistrarUsuario(Usuario user)
        {
            var rowsAffected = 1;
            //var tabla = new tUsuario();
            //tabla.Identificacion = user.Identificacion;
            //tabla.Nombre = user.Nombre;
            //tabla.Correo = user.Correo;
            //tabla.Contrasenna = user.Contrasenna;
            //tabla.Estado = true;
            //tabla.IdRol = 1;

            //using (var context = new MARTES_BDEntities())
            //{
            //    context.tUsuario.Add(tabla);
            //    context.SaveChanges();
            //    //manera de trabajo con entity framework 
            //    // MANERA 1 DE TRABAJAR CON LA BASE DE DATOS
            //    }


                //MANERA 2 DE TRABAJAR CON LA BASE DE DATOS en un procedimiento almacenado
                using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.RegistrarUsuario(user.Identificacion, user.Nombre, user.Correo, user.Contrasenna);
            }


            return (rowsAffected > 0 ? true : false); //operador ternario
        }

        public bool IniciarSesion(Usuario user)
        {
            var rowCount = 0;
            //using (var context = new MARTES_BDEntities())
            //{                                                                                                                                       
            //    var resultado = (from x in context.tUsuario
            //                    where x.Correo == user.Correo 
            //                    && x.Contrasenna == user.Contrasenna
            //                    && x.Estado == true
            //                    select x).ToList();

            //}
            using (var context = new MARTES_BDEntities1())
            {
                rowCount = context.IniciarSesion( user.Correo, user.Contrasenna).ToList().Count();
            }

            return (rowCount > 0 ? true : false);
        }

    }
}