<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tos.aspx.cs" Inherits="Tos" Title="Term of Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="toolbar"><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button"/>Term of Service</div>
    <div id="main">
        <div id="content">
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
	    </div>	
	    <div id="btn_menu">			    
            <asp:Button ID="btnAgree" runat="server" Text="I Agree" CssClass="tr_button" OnClick="btnAgree_Click" /><br /><br />                   
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="tr_button" OnClick="btnCancel_Click" />
        </div>
    </div>    
</asp:Content>

