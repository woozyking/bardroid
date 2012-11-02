<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CardReader.aspx.cs" Inherits="CardReader" Title="Bar Droid" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">   
    <div id="toolbar"><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button"/>Age Identification</div>    
    <div id="main">
        <div id="content">
	        <p style="text-align: center"><asp:Label ID="MessageText" runat="server" Text="Label"></asp:Label></p>
        </div>			
	    <div id="btn_menu">			    
            <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="tr_button" OnClick="btnOk_Click" /><br /><br />                    
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="tr_button" OnClick="btnCancel_Click" />
        </div>
        <div class="centerDiv">
            <asp:Label ID="ErrorBox" runat="server" ForeColor="red" Visible="false" Text="There was an error reading your card. Please try again."></asp:Label>        
        </div>
    </div>
</asp:Content>

