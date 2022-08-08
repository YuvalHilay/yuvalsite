<%@ Page Title="" Language="C#" MasterPageFile="~/mpMain.Master" AutoEventWireup="true" CodeBehind="wfCatalog.aspx.cs" Inherits="MyWebApplication.PagesForVisitors.wfCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
        .auto-style14 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:GridView ID="GridView1" runat="server" Height="36px" Width="1095px" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="IDProduct" DataSourceID="SqlDataSource1" CssClass="auto-style14" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowPaging="True">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="IDProduct" HeaderText="קוד מוצר" InsertVisible="False" ReadOnly="True" SortExpression="IDProduct" />
        <asp:BoundField DataField="ProductName" HeaderText="שם מוצר" SortExpression="ProductName" />
        <asp:BoundField DataField="Price" HeaderText="מחיר" SortExpression="Price" DataFormatString="{0:c}" />
        <asp:ImageField DataImageUrlField="ProductImage" DataImageUrlFormatString="~/Images/Products/{0}" HeaderText="תמונה" SortExpression="ProductImage">
            <ControlStyle Height="150px" />
            <FooterStyle Height="150px" />
        </asp:ImageField>
    </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [IDProduct], [ProductName], [Price], [ProductImage] FROM [spViewActiveProducts]"></asp:SqlDataSource>
    <asp:Label ID="lblMsg" runat="server" style="color: #FFFF00"></asp:Label>
</asp:Content>


