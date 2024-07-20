using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (id != "")
                    {
                        cargarDetalleArticulo(id);
                    }
                    else
                        Response.Write("ID no válido.");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargarDetalleArticulo(string id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> articulos = negocio.listar(id); 
                if (articulos != null && articulos.Count > 0)
                {
                    Articulo articulo = articulos[0];
                    lblNombre.Text = articulo.Nombre;
                    lblCodigo.Text = articulo.Codigo;
                    lblPrecio.Text = articulo.Precio.ToString("F2");
                    lblMarca.Text = articulo.Marca.Descripcion;
                    lblCategoria.Text = articulo.Categoria.Descripcion;
                    lblDescripcion.Text = articulo.Descripcion;
                    cargarImagen(articulo.ImagenUrl);
                }
                else 
                {
                    Session.Add("error", "El artículo no se encuentra en el catálogo.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {                
                if (!string.IsNullOrEmpty(imagen))
                {
                    imgArticulo.ImageUrl = imagen;
                }
                else
                {
                    imgArticulo.ImageUrl = "https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg";
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