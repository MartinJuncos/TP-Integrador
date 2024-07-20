using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("insert into USERS (email, pass, nombre, apellido, admin) output inserted.id values (@email, @pass, @nombre, @apellido, 0)");
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Pass);
				datos.setearParametro("@nombre", usuario.Nombre);
				datos.setearParametro("@apellido", usuario.Apellido);
				return datos.ejecutarAccionScalar();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

		public bool Login(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select id, urlImagenPerfil, email, pass, admin, nombre, apellido from USERS Where email = @email And pass = @pass");
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Pass);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["id"];
					usuario.Admin = (bool)datos.Lector["admin"];
					if (!(datos.Lector["urlImagenPerfil"] is DBNull))
						usuario.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
					if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido Where Id = @id");
                datos.setearParametro("@imagen", (object)usuario.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@id", usuario.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
