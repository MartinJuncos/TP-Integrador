using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace presentacion
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                    }
                }
			}
			catch (Exception ex)
			{
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
			}
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)                  
                    return;

                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                negocio.actualizar(usuario);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}