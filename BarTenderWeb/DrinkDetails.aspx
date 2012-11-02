<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DrinkDetails.aspx.cs" Inherits="DrinkDetails" Title="Drink Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="toolbar"><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button"/><asp:Label ID="DrinkName" runat="server" Text="DrinkName"></asp:Label></div>    
    <div id="main">
        <div id="content">
	        <table style="margin: 0 auto; padding: 15px; width: 50%;" border="0">
            <tr>                    
                <td valign="top">
                    <p><asp:Label ID="lblIngredients" runat="server" Text="Description" Font-Bold="True" Font-Underline="True"></asp:Label></p>
                    <p><asp:Label ID="DrinkDescription" runat="server" Text="Label"></asp:Label></p>	                    
                </td>
                <td>                                                    
                    <asp:Image ID="DrinkImage" runat="server"/>
                </td>                  
            </tr>
            </table>
        </div>			
	    <div id="btn_menu">			    
            <asp:Button ID="btnPour" runat="server" Text="Pour Drink" CssClass="tr_button" OnClick="btnPour_Click" /><br /><br />                    
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="tr_button" OnClick="btnCancel_Click" />
        </div>
    </div>

</asp:Content>

