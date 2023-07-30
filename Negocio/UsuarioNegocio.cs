using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)//metodo para ir a la db
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select id, email, pass, admin from USERS where email = @email and pass = @pass");
                //generamos la consultas a la base de datos, table users
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);

                datos.EjecutarLectura();
                //en el while solo vamos a completar con los datos que faltan
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.TipoUsuario = (bool)(datos.Lector["admin"]);
                    return true;
                    //si el lector lee va a dar true ya que encontro el el mail  y el pass en la db, sino
                    //dara falso.

                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

