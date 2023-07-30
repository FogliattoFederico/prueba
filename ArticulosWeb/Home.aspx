<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ArticulosWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Articulos</h1>
    <div class="row">
        <div class="col-3">
            <asp:Label Text="Campo" CssClass="form-label" runat="server" />
            <asp:DropDownList ID="ddlCampo" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                <asp:ListItem Text="Precio" />
                <asp:ListItem Text="Codigo" />
                <asp:ListItem Text="Nombre" />
            </asp:DropDownList>
        </div>
        <div class="col-3">
            <asp:Label Text="Criterio" CssClass="form-label" runat="server" />
            <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-3">
            <asp:Label Text="Filtro" CssClass="form-label" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" runat="server" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <hr />
    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false"
        AllowPaging="true" PageSize="3" CssClass="table table-warning table-bordered">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="📖" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>













