<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Staff Login"%>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">      

</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">            	    
    <div id="toolbar">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="tr_button"/>Staff Login</div>	    
    <div id="main">
	    <div id="content">
	        <div class="centerDiv">
	            <span class="input_spn">Username:</span><asp:TextBox ID="tbusername" runat="server"></asp:TextBox><br />
                <span class="input_spn">Password:</span><asp:TextBox ID="tbpassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <!-- <input ID="btnSubmit" type="submit" rel="external" value="Submit"> -->
	    <div id="btn_menu">			    
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="tr_button" />
            <div class="centerDiv">
                <asp:Label ID="ErrorBox" runat="server" ForeColor="red" Visible="false" Text="Incorrect Password"></asp:Label>        
            </div>
        </div>
    </div>    
</asp:Content>
