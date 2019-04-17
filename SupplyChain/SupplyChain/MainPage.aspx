<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SupplyChain.MainPage" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form class="form-signin">
        <img alt="" src="images/supplychain.jpg" class="form-img" />
        <input id="TextBox1" type="text" placeholder="ID" class="form-control" required="required" />
        <br />
        <input id="VerifyButton" class="btn btn-lg btn-danger btn-block" type="button" value="Verify" onclick="VerifyButtonClick" runat="server"/>
    </form>
            
</asp:Content>
