<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BarDroid.aspx.cs" Inherits="_Default" Title="Bar Droid" %>


<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <div id="toolbar">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button" />Bar Droid</div>    
    <div id="main">
        <div id="content">
	        <p style="text-align:center;">To get started, please select your beverage type.</p>
        </div>			
	    <div id="btn_menu">			    
            <asp:Button ID="btnliquor" runat="server" OnClick="btnliquor_Click" Text="Liquor" CssClass="tr_button" /><br /><br />                    
            <asp:Button ID="btnpop" runat="server" OnClick="btnpop_Click" Text="Pop" CssClass="tr_button" />
        </div>
    </div>
</asp:Content>