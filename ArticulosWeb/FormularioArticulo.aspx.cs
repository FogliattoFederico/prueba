using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ArticulosWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        //propiedad utilizada para ocultar o mostrar los controles de eliminacion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == true))
                {
                    Session.Add("error", "No tienes permisos de ADMIN");
                    Response.Redirect("Error.aspx", false);
                }

                txtId.Enabled = false;
                ConfirmaEliminacion = false;
                // la propiedead esta por defecto en false;

                if (!IsPostBack)
                {
                    //configuracion inical
                    //carga de opciones de los desplegables
                    MarcaNegocio negocio = new MarcaNegocio();
                    List<Marca> listMarca = negocio.Listar();
                    ddlMarca.DataSource = listMarca;
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();


                    CategoriaNegocio negocio1 = new CategoriaNegocio();
                    List<Categoria> listCategoria = negocio1.Listar();
                    ddlCategoria.DataSource = listCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                }

                //configuracion si estamos modificando

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                //con el operador ternario verificamos si traemos un ID, de ser asi, se lo agregamos al
                //metodo listar como parametro
                if (id != "" && !IsPostBack) //se deben cumplir ambas condiciones
                {
                    //creamos una lista de articulos la cual solo tendra un articulo a traves del metodo 
                    //listar. Luego creamos un objeto de tipo articulo y le asignamos el indice 0 de la 
                    //lista o como sabemos que listar devuelve una lista, simplemente le asignamos el
                    //indice 0 al objeto "seleccionado"

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    //List<Articulo> lista = negocio.Listar2(id);

                    Articulo seleccionado = (negocio.Listar2(id))[0];

                    //precarga del articulo
                    txtId.Text = seleccionado.Id.ToString();
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagen.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    //precarga de desplegables
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();

                    //precarga de la imagen
                    txtImagen_TextChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }

        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            //evento de cargar imagen proveniente de la caja de texto imagen
            imgArticulo.ImageUrl = txtImagen.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {


                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = imgArticulo.ImageUrl;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"].ToString());//linea fundamental para
                                                                               //que modifique la db
                    negocio.modificar(nuevo);
                }
                else
                    negocio.agregar(nuevo);
                //si vino un Id es modificar, sino es agregar

                Response.Redirect("Home.aspx", false);
                //false es para evitar error por "aborto de hilo"

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());

            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)//primer boton de eliminar
        {
            ConfirmaEliminacion = true; //al presionar en el boton cancelar, modificamos a true la propiedad
        }
        protected void btnConfirma_Click(object sender, EventArgs e)//es el segundo boton de eliminar
        {
            try
            {
                if (chbEliminar.Checked)//si la casilla esta tildada ejecuta la eliminacion
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("home.aspx", false);

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

    }







}




