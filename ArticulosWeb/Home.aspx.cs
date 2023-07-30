using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ArticulosWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)// de esta forma evitamos que el usuario pueda ingresar a la
            // pagina escribiendo la direccion en la barra navegadora. Solo accede logeandose
            {
                Session.Add("error", "Debes loguearte para poder acceder a esta seccion");
                Response.Redirect("Error.aspx");
            }

            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == true))
            {
                //aqui validamos para que a la pagina de home solo pueda acceder el ADMIN
                Session.Add("error", "No tienes permisos de ADMIN");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("negocio", negocio.Listar2());
                dgvArticulos.DataSource = Session["negocio"];
                dgvArticulos.DataBind();

            }
        }
        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Para hacer configurar la paginacion junto con el "allowPaging = true" y "pageSize"

            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.Listar2();
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //en el front utilizamos el datakey y este metodo para enviar el id del articulo seleccionado
            // a traves del "showSelectedButton"
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //utilizamos este evento junto al autopostback en true para que carge el desplegable de criterio
            //segun lo elegido en el desplegable de campo

            ddlCriterio.Items.Clear(); //evita que se acumulen las opciones en ele ddlcriterio

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contine");
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltro.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}








