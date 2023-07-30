<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ArticulosWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hubo un error...</h1>
    <asp:Label Text="" ID="lblerror" runat="server" />
    <div>
        <a href="Login.aspx">Volver</a>
    </div>
</asp:Content>


