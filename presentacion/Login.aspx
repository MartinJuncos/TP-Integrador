<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
     <script type="text/javascript">
         document.addEventListener('DOMContentLoaded', function () {
             var form = document.forms[0];
             form.addEventListener('keydown', function (e) {
                 if (e.key === 'Enter') {
                     e.preventDefault();
                     document.getElementById('<%= btnIngresar.ClientID %>').click();
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Iniciar Sesión</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />    
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" />
            </div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
