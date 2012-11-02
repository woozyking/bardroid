<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Owner.aspx.cs" Inherits="Owner" Title="Staff Menu" %>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <div id="toolbar">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button" />Staff Options</div>    
    <div id="main">
        <div id="content">	        
        </div>			
	    <div id="btn_menu">			    
            <asp:Button ID="btnStart" runat="server" Text="Start Bar Droid" CssClass="tr_button" OnClick="btnStart_Click" /><br /><br />
            <asp:Button ID="btnSetPump" runat="server" Text="Set Pump" CssClass="tr_button" OnClick="btnSetPump_Click" /><br /><br />
            <asp:Button ID="btnAddDrinks" runat="server" Text="Add Drinks" CssClass="tr_button" OnClick="btnAddDrinks_Click" />
        </div>
    </div>
</asp:Content>
