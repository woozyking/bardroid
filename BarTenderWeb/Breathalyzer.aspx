<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Breathalyzer.aspx.cs" Inherits="Breathalyzer" Title="Breathalyzer Test" %>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">	
	<div id="toolbar"><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button"/>Breathalyzer Test</div>	
	<div id="main">
	    <div id="content">
		    <p style="text-align:center;"><asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label></p>
	    </div>			
		<div id="btn_menu">			    
            <asp:Button ID="btnStart" runat="server" Text="Start" CssClass="tr_button" OnClick="btnStart_Click" /><br /><br />                 
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="tr_button" OnClick="btnCancel_Click" />
        </div>
	</div> 		
</asp:Content>

