using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPassword))
                {
                    Session.Add("error", "Debes completar ambos campos!!");
                    Response.Redirect("Error.aspx");
                }

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o Contraseña icorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}