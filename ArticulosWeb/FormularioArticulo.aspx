<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="ArticulosWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function ValidarCodigo() {

            const txtCodigo = document.getElementById("txtCodigo");

            if (txtCodigo.value == "") {

                alert("Completar el campo CODIGO");
                return false;
            }
            return true;
        }

        function ValidarNombre() {

            const txtNombre = document.getElementById("txtNombre");

            if (txtNombre.value == "") {

                alert("Completar el campo NOMBRE");
                return false;
            }
            return true;
        }

        function ValidarDescripcion() {

            const txtDescripcion = document.getElementById("txtDescripcion");

            if (txtDescripcion.value == "") {

                alert("Completar el campo DESCRIPCION");
                return false;
            }
            return true;
        }

        function ValidarPrecio() {

            const txtPrecio = document.getElementById("txtPrecio");

            if (txtPrecio.value == "") {

                alert("Completar el campo PRECIO");
                return false;
            }
            return true;
        }

        function ValidarImagen() {

            const txtImagen = document.getElementById("txtImagen");

            if (txtImagen.value == "") {

                alert("Completar el campo IMAGEN");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3">
            <asp:Label Text="Id" CssClass="form-label" runat="server" />
            <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
        </div>
        <div class="col-3">
            <asp:Label Text="Codigo" CssClass="form-label" runat="server" />
            <asp:TextBox ID="txtCodigo" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
        <div class="col-6">
            <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
            <asp:TextBox ID="txtNombre" ClientIDMode="Static" runat="server" CssClass="form-control" />
        </div>
    </div>
    <div>
        <asp:Label Text="Descripcion" CssClass="form-label" runat="server" />
        <asp:TextBox ID="txtDescripcion" ClientIDMode="Static" runat="server" TextMode="MultiLine" CssClass="form-control" />
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label Text="Marca" runat="server" CssClass="form-label" />
            <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>
        <div class="col-4">
            <asp:Label Text="Categoria" runat="server" CssClass="form-label" />
            <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>
        <div class="col-4">
            <asp:Label Text="Precio" runat="server" CssClass="form-label" />
            <asp:TextBox ID="txtPrecio" ClientIDMode="Static" runat="server" CssClass="form-control" />
        </div>
    </div>
    <div class="col-8">
        <asp:Label Text="Imagen" CssClass="form-label" runat="server" />
        <asp:TextBox runat="server" ID="txtImagen" ClientIDMode="Static" CssClass="form-control" AutoPostBack="true"
            OnTextChanged="txtImagen_TextChanged" />
    </div>
    <hr />
    <div class="row">
        <div class="col-9">
            <asp:Image ImageUrl="https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png"
                ID="imgArticulo" Width="40%" runat="server" />
        </div>
        <div class="col-3">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel ID="updatepanel1" runat="server">
                <ContentTemplate>
                    <asp:Button Text="Guardar" ID="btnGuardar" OnClientClick="ValidarNombre(), 
                        ValidarCodigo(), ValidarDescripcion(), ValidarPrecio(), ValidarImagen()"
                        CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" />
                    <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" runat="server" />
                    <hr />
                    <%if (ConfirmaEliminacion)//si esta en true, muestra los controles
                        {%>
                    <div class="col-8">
                        <asp:CheckBox Text="Confirmar eliminacion" ID="chbEliminar" CssClass="form-control" runat="server" />
                    <asp:Button Text="Eliminar" ID="btnConfirma" CssClass="btn btn-outline-danger" OnClick="btnConfirma_Click" runat="server" />
                    </div>
                    <%  } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>




























































</asp:Content>













