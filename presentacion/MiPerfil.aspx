<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="presentacion.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>           
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtApellido" runat="server" />
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" Width="200px" CssClass="img-fluid mb-3"
                ImageUrl="https://www.nicepng.com/png/full/799-7998295_profile-placeholder-woman-720-profile-photo-placeholder-png.png"
                runat="server" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
