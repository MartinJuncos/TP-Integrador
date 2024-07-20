<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            width: 300px;
            height: 310px;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }

        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: cover;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <asp:Image ID="imagen" class="card-img-top" runat="server" AlternateText="Imagen del artículo" />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <h6><%#Eval("Precio", "{0:F2}") %></h6>
                            <a href="VerDetalle.aspx?id=<%#Eval("Id")%> ">Ver Detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
