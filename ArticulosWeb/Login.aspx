<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArticulosWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <asp:Label Text="Email" CssClass="form-label" runat="server" />
            <asp:TextBox runat="server" ID="txtMail"  CssClass="form-control" />
        </div>
        <div class="col-4"></div>
    </div>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <asp:Label Text="Password" CssClass="form-label" runat="server" />
            <asp:TextBox runat="server" type="password" ID="txtPass" CssClass="form-control" />
        </div>
        <div class="col-4"></div>
    </div>
    <br />
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <asp:Button Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click"
                CssClass="btn btn-primary" runat="server" />
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>


