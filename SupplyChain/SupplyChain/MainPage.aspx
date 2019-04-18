<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SupplyChain.MainPage" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form-signin">  
        <img alt="" src="images/supplychain.jpg" class="form-img" />
        <asp:TextBox ID="ProductIdTextbox" CssClass="form-control" runat="server" ></asp:TextBox>
        <br />
        <asp:Button ID="VerifyButton1" Text="Verify" runat="server" OnClick="VerifyButtonClick" CssClass="btn btn-lg btn-danger btn-block" />
    </div>
      
</asp:Content>
