<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="presentacion.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El código es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El precio es requerido" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtPrecio" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese un número decimal válido" ValidationExpression="^\d+(\.\d+)?$|^\d+(,\d+)?$" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtPrecio" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" CssClass="btn btn-primary" />
                <a href="ListaArticulos.aspx">Cancelar</a>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="La descripción es requerida" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtDescripcion" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="La descripción no puede tener mas de 150 caracteres" ValidationExpression="^.{1,150}$" ForeColor="Red" Font-Size="14px" Font-Bold="true" ControlToValidate="txtDescripcion" runat="server" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" OnTextChanged="txtImagenUrl_TextChanged" CssClass="form-control" AutoPostBack="true" />
                        <asp:RequiredFieldValidator ErrorMessage="La URL es requerida" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtImagenUrl" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="La URL de imagen no puede tener mas de 1000 caracteres" ValidationExpression="^.{1,1000}$" ForeColor="Red" Font-Size="14px" Font-Bold="true" ControlToValidate="txtImagenUrl" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Image runat="server" ID="imgArticulo" Width="60%" onerror="this.onerror=null;this.src='https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg';" />                      
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" CssClass="btn btn-danger" />
                    </div>

                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" runat="server" CssClass="btn btn-outline-danger" />
                    </div>
                    <%  } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
