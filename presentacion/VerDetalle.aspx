<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="presentacion.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle del Artículo</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Image runat="server" ID="imgArticulo" Width="40%" AlternateText="Imagen del Artículo" onerror="this.onerror=null;this.src='https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg';" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="lblNombre" class="form-label">Nombre: </label>
                <asp:Label Text="" ID="lblNombre" class="form-label" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblCodigo" class="form-label">Código: </label>
                <asp:Label Text="" ID="lblCodigo" class="form-label" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblPrecio" class="form-label">Precio: </label>
                <asp:Label Text="" ID="lblPrecio" class="form-label" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblMarca" class="form-label">Marca: </label>
                <asp:Label Text="" ID="lblMarca" class="form-label" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblCategoria" class="form-label">Categoria: </label>
                <asp:Label Text="" ID="lblCategoria" class="form-label" runat="server" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <label for="lblDescripcion" class="form-label">Descripción: </label>
            <asp:Label Text="" ID="lblDescripcion" class="form-label" runat="server" />
        </div>
    </div>


</asp:Content>
