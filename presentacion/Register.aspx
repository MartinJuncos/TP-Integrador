<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="presentacion.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
     document.addEventListener('DOMContentLoaded', function () {
         var form = document.forms[0]; 
         form.addEventListener('keydown', function (e) {
             if (e.key === 'Enter') {
                 e.preventDefault();
                 document.getElementById('<%= btnRegistrarse.ClientID %>').click();
            }
        });
    });
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Crear Cuenta</h2>
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El email es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingresá un email válido." ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtPassword" runat="server" />
            </div>
            <asp:Button Text="Crear Cuenta" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" ID="btnRegistrarse" runat="server" />
            <a href="/">Cancelar</a>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtApellido" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
