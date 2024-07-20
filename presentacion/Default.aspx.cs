using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string filtro = Request.QueryString["filtro"];
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        filtrarArticulos(filtro);
                    }                    
                    else
                        cargar();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();
            Session.Add("listaArticulos", ListaArticulos);
            repRepetidor.DataSource = Session["listaArticulos"];
            repRepetidor.DataBind();
        }

        private void filtrarArticulos(string filtro)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            if (lista != null)
            {
                List<Articulo> listaFiltrada = new List<Articulo>();
                if (!string.IsNullOrEmpty(filtro))
                {
                    listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));

                    if (listaFiltrada.Count > 0)
                    {
                        repRepetidor.DataSource = listaFiltrada;
                        repRepetidor.DataBind();
                    }
                    else
                    {
                        Session.Add("error", "No se encontraron artículos que coincidan con el filtro.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Image imagen = (Image)e.Item.FindControl("imagen");

                    if (imagen != null)
                    {
                        string imagenUrl = DataBinder.Eval(e.Item.DataItem, "ImagenUrl").ToString();
                        string defaultImageUrl = "https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg";

                        imagen.ImageUrl = string.IsNullOrEmpty(imagenUrl) ? defaultImageUrl : imagenUrl;

                        imagen.Attributes.Add("onerror", $"this.onerror=null;this.src='{defaultImageUrl}';");
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        } 
    }
}