<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SupplyChain.MainPage" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form-signin" style="text-align: center;">  
        <img alt="" src="images/supplychain.png" class="form-img" />
        <asp:TextBox ID="ProductIdTextbox" onkeydown = "return (event.keyCode!=13);" CssClass="form-control" runat="server" ></asp:TextBox>
        <asp:Button ID="VerifyButton1" Text="Verify" runat="server" OnClick="VerifyButtonClick" CssClass="btn btn-lg btn-danger btn-block" style="margin-top: 10px;"/>
    </div>
      
</asp:Content>
