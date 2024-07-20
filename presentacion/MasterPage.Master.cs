using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Win32;
using negocio;

namespace presentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                imgAvatar.ImageUrl = "https://www.nicepng.com/png/full/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
                if (!(Page is Login || Page is Register || Page is Default || Page is Error || Page is VerDetalle))
                {
                    if (!(Seguridad.sesionActiva(Session["usuario"])))
                        Response.Redirect("Login.aspx", false);
                    else
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        lblUser.Text = usuario.Email;
                        if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                            imgAvatar.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                    }
                }
                else
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        lblUser.Text = usuario.Email;
                        if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                            imgAvatar.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            if (!string.IsNullOrEmpty(filtro))
            {
                Response.Redirect("Default.aspx?filtro=" + filtro);
                txtFiltro.Text = string.Empty;
            }
            else
            {
                Session.Add("error", "Escriba algo en el buscador por favor!");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}