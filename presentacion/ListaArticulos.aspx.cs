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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Seguridad.esAdmin(Session["usuario"])))
                {
                    Session.Add("error", "Se requiere permisos de admin para acceder a esta pantalla.");
                    Response.Redirect("Error.aspx", false);
                }

                if (!IsPostBack)
                {
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
            Session.Add("listaArticulos", negocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (Session["listaFiltrada"] != null)
                    dgvArticulos.DataSource = Session["listaFiltrada"];
                else
                    dgvArticulos.DataSource = Session["listaArticulos"];

                dgvArticulos.PageIndex = e.NewPageIndex;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                Session.Add("listaFiltrada", listaFiltrada);
                dgvArticulos.DataSource = Session["listaFiltrada"];
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAvanzado.Checked)
                {
                    txtFiltro.Enabled = false;
                    cargarDesplegables();
                }
                else
                    txtFiltro.Enabled = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargarDesplegables()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            ddlMarca.DataSource = marcaNegocio.listar();
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem(" Selecciona una marca ", ""));
            ddlMarca.SelectedIndex = 0;


            ddlCategoria.DataSource = categoriaNegocio.listar();
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem(" Seleccione una categoría ", ""));
            ddlCategoria.SelectedIndex = 0;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                List<Articulo> listaArticulos = Session["ListaArticulos"] as List<Articulo>;

                if (listaArticulos != null)
                {
                    var articulosFiltrados = listaArticulos.AsQueryable();

                    if (ddlMarca.SelectedIndex > 0)
                    {
                        int seleccionMarcaId = int.Parse(ddlMarca.SelectedValue);
                        articulosFiltrados = articulosFiltrados.Where(x => x.Marca.Id == seleccionMarcaId);
                    }

                    if (ddlCategoria.SelectedIndex > 0)
                    {
                        int seleccionCategoriaId = int.Parse(ddlCategoria.SelectedValue);
                        articulosFiltrados = articulosFiltrados.Where(x => x.Categoria.Id == seleccionCategoriaId);
                    }

                    if (!string.IsNullOrWhiteSpace(txtPrecioMin.Text))
                    {
                        decimal precioMinimo = decimal.Parse(txtPrecioMin.Text);
                        articulosFiltrados = articulosFiltrados.Where(x => x.Precio >= precioMinimo);
                    }

                    if (!string.IsNullOrWhiteSpace(txtPrecioMax.Text))
                    {
                        decimal precioMaximo = decimal.Parse(txtPrecioMax.Text);
                        articulosFiltrados = articulosFiltrados.Where(x => x.Precio <= precioMaximo);
                    }

                    Session.Add("listaFiltrada", articulosFiltrados.ToList());
                    dgvArticulos.DataSource = Session["listaFiltrada"];
                    dgvArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            cargar();
        }

        private void LimpiarFiltros()
        {
            ddlMarca.SelectedIndex = 0; 
            ddlCategoria.SelectedIndex = 0; 
            txtPrecioMin.Text = string.Empty;
            txtPrecioMax.Text = string.Empty;
            LimpiarListaFiltrada();
        }

        private void LimpiarListaFiltrada()
        {
            Session.Remove("listaFiltrada");
        }
    }
}