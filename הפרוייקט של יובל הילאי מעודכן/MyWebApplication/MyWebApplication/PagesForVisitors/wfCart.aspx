﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpMain.Master" AutoEventWireup="true" CodeBehind="wfCart.aspx.cs" Inherits="MyWebApplication.PagesForVisitors.wfCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
    .auto-style14 {
        height: 20px;
    }
        .auto-style15 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="auto-style7" style="height: 737px">
    <tr>
        <td style="text-align: center; color: #FFFF00;" class="auto-style15">סל הקניות שלי</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvCart" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="645px" Width="1159px" AutoGenerateDeleteButton="True" OnRowDeleting="gvCart_RowDeleting">
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
        </td>
    </tr>
    <tr>
        <td class="auto-style14">
            <asp:Label ID="lblMsg" runat="server" style="text-align: center; color: #FFFF00;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style14">
            <asp:Label ID="lblTotal" runat="server" style="color: #FFFF00"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnOrder" runat="server" Text="Order Now" OnClick="btnOrder_Click1" style="color: #FF3300; background-color: #FFFF00" />
            <asp:Button ID="LevelDiscount" runat="server" OnClick="LevelDiscount_Click" style="color: #000000; background-color: #00FFFF" Text="לחץ על מנת להשתמש בהנחה המגיעה לרמה שלך" Width="1059px" />
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder6">
                        <asp:Image ID="Image18" runat="server" Height="1175px" ImageUrl="~/Images/General/battlefield_1_soldiers_5k-HD.jpg" style="margin-right: 2px; margin-top: 0px" Width="478px" />
                    </asp:Content>

