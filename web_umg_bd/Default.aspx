<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_umg_bd._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbl_producto" runat="server" CssClass="badge" Text="producto"></asp:Label>
    <asp:TextBox ID="txt_producto" runat="server" CssClass="form-control" placeholder="INGRESE PRODUCTO"></asp:TextBox>
    <asp:Label ID="lbl_descripcion" runat="server" CssClass="badge" Text="descripcion" placeholder="DRESCRIPCION"></asp:Label>
    <asp:TextBox ID="txt_descripcion" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lbl_precioc" runat="server" CssClass="badge" Text="precio costo"></asp:Label>
    <asp:TextBox ID="txt_precioc" runat="server" CssClass="form-control" TextMode="Number" placeholder="0.00"></asp:TextBox>
    <asp:Label ID="lbl_preciov" runat="server" CssClass="badge" Text="precio venta"></asp:Label>
    <asp:TextBox ID="txt_preciov" runat="server" CssClass="form-control" TextMode="Number" placeholder="0.00"></asp:TextBox>
    <asp:Label ID="lbl_existencia" runat="server" CssClass="badge" Text="existencia"></asp:Label>
    <asp:TextBox ID="txt_existencia" runat="server" CssClass="form-control" placeholder="0"></asp:TextBox>
    <asp:Label ID="lbl_sangre" runat="server" CssClass="badge" Text="marca"></asp:Label>
    <asp:DropDownList ID="drop_marca" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_marca_SelectedIndexChanged"></asp:DropDownList>
    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-info btn-lg" OnClick="btn_agregar_Click" />
    <asp:Button ID="btn_modificar" runat="server" OnClick="btn_modificar_Click" Text="Modificar" CssClass="btn btn-success btn-lg" Visible="False" />
    <asp:Label ID="lbl_mensaje" runat="server" CssClass="alert-info"></asp:Label>
    <asp:GridView ID="grid_productos" runat="server" AutoGenerateColumns="False" CssClass="table-condensed" DataKeyNames="id,id_marca" OnRowDeleting="grid_productos_RowDeleting" OnSelectedIndexChanged="grid_productos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Ver" ShowSelectButton="True" ControlStyle-CssClass="btn btn-info" >
<ControlStyle CssClass="btn btn-info"></ControlStyle>
            </asp:CommandField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea Eliminar?'))return false"  />
                </ItemTemplate>
                <ControlStyle CssClass="btn btn-danger" />
            </asp:TemplateField>
            <asp:BoundField DataField="producto" HeaderText="producto" />
            <asp:BoundField DataField="descripcion" HeaderText="descripcion" />
            <asp:BoundField DataField="precioc" HeaderText="precio costo" />
            <asp:BoundField DataField="preciov" HeaderText="precio venta" />
            <asp:BoundField DataField="existencia" HeaderText="existencia" />
            <asp:BoundField DataField="marca" HeaderText="marca" />
        </Columns>
    </asp:GridView>
</asp:Content>
