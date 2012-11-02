<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="BarDroid"%>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <div id="toolbar">BarDroid</div>	
	<div id="main">
	    <div id="content">		
	    </div>			
		<div id="btn_menu">			    
            <asp:Button ID="btndrinkmenu" runat="server" OnClick="btndrinkmenu_Click" Text="Drink Menu" CssClass="tr_button" /><br /><br />                 
            <asp:Button ID="btnstafflogin" runat="server" OnClick="btnstafflogin_Click" Text="Staff Login" CssClass="tr_button" />
        </div>
	</div>        
</asp:Content>
