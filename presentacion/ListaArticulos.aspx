<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="presentacion.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Artículos</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox ID="txtFiltro" OnTextChanged="txtFiltro_TextChanged" CssClass="form-control" AutoPostBack="true" runat="server" />
            </div>
        </div>

        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
            </div>
        </div>


        <%if (chkAvanzado.Checked)
            {%>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Marca" runat="server" />
                    <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Categoría" runat="server" />
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Precio Mínimo" runat="server" />
                    <asp:TextBox ID="txtPrecioMin" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ErrorMessage="Ingrese un número decimal válido" ValidationExpression="^\d+(\.\d+)?$" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtPrecioMin" runat="server" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Precio Máximo" runat="server" />
                    <asp:TextBox ID="txtPrecioMax" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ErrorMessage="Ingrese un número decimal válido" ValidationExpression="^\d+(\.\d+)?$" Style="color: red; font-size: 14px; font-weight: bold;" ControlToValidate="txtPrecioMax" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Borrar Filtros" CssClass="btn btn-primary" ID="btnBorrarFiltro" OnClick="btnBorrarFiltro_Click" runat="server" />
                </div>
            </div>
        </div>
        <% } %>
    </div>

    <asp:GridView ID="dgvArticulos" CssClass="table" DataKeyNames="Id"
        AutoGenerateColumns="false" runat="server" AllowPaging="true"
        PageSize="10" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" HtmlEncode="False" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
