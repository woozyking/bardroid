<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Drinks.aspx.cs" Inherits="Drinks" Title="Drinks" %>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">    
    <div id="toolbar">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button" />Drink Menu
    </div>   
    <div id="main">
        <div id="content">
	        <p style="text-align: center">Please select a drink.</p>
        </div>			
	    <div id="btn_menu">			    
            <asp:literal ID="DrinkMenu" runat="server"></asp:literal>
        </div>
    </div>                
</asp:Content>
