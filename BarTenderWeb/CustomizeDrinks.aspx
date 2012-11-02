<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomizeDrinks.aspx.cs" Inherits="CustomizeDrinks" Title="Customize Your Drinks" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="euronetwebcontrols" Namespace="EuroNetWebControls" Assembly="EuroNetWebControls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="toolbar"><asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="tr_button"/>Customize Your Drinks</div>	
	<div id="main">        
        <div id="content">
            <div style="text-align: center; width:100%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<asp:Label id="lblInstr" runat="server" Text="Please select the number of shots per drink type."></asp:Label> <asp:Panel id="pnSetPump" runat="server">
                    <table style="text-align: center;">
                        <tr>
                            <td>Pump Number</td>
                            <td>Liquid Name</td>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td><asp:TextBox ID="tbMotor1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td><asp:TextBox ID="tbMotor2" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td><asp:TextBox ID="tbMotor3" runat="server"></asp:TextBox></td>
                        </tr>
                    </table> 
                </asp:Panel> <asp:Panel id="pnCustomize" runat="server"><asp:Panel id="pnNameOfDrink" runat="server">
                            <br />
                            <strong>Name of Drink:</strong> <asp:TextBox ID="tbDrinkName" runat="server"></asp:TextBox>
                            <br />
                        </asp:Panel> <asp:Label id="lblMotor1" runat="server" Text="Label" Font-Bold="True"></asp:Label><BR /><asp:Button id="btnDown1" onclick="btnDown1_Click" runat="server" CssClass="tr_buttonSmall" Text="<"></asp:Button> <asp:TextBox style="TEXT-ALIGN: center" id="TextBox1" runat="server" ReadOnly="True">0</asp:TextBox> <asp:Button id="btnUp1" onclick="btnUp1_Click" runat="server" CssClass="tr_buttonSmall" Text=">"></asp:Button> <BR /><asp:Label id="lblMotor2" runat="server" Text="Label" Font-Bold="True"></asp:Label><BR /><asp:Button id="btnDown2" onclick="btnDown2_Click" runat="server" CssClass="tr_buttonSmall" Text="<"></asp:Button> <asp:TextBox style="TEXT-ALIGN: center" id="TextBox2" runat="server" ReadOnly="True">0</asp:TextBox> <asp:Button id="btnUp2" onclick="btnUp2_Click" runat="server" CssClass="tr_buttonSmall" Text=">"></asp:Button> <BR /><asp:Label id="lblMotor3" runat="server" Text="Label" Font-Bold="True"></asp:Label><BR /><asp:Button id="btnDown3" onclick="btnDown3_Click" runat="server" CssClass="tr_buttonSmall" Text="<"></asp:Button> <asp:TextBox style="TEXT-ALIGN: center" id="TextBox3" runat="server" ReadOnly="True">0</asp:TextBox> <asp:Button id="btnUp3" onclick="btnUp3_Click" runat="server" CssClass="tr_buttonSmall" Text=">"></asp:Button> <BR /></asp:Panel> 
</ContentTemplate>
            </asp:UpdatePanel>
            </div>        
        </div>		            	
        <div id="btn_menu">			    
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="tr_button" OnClick="btnSave_Click"/><br />
            <asp:Label ID="lbbSaveResult" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>          
	</div>
</asp:Content>

