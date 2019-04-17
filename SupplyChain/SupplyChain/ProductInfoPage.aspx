<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInfoPage.aspx.cs" Inherits="SupplyChain.ProductInfoPage" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 10px; padding: 10px;">
        <div style="float: left">
            <div style="float: left; text-align: right; padding: 10px">
                <asp:Label ID="DateLabel" runat="server" Text="Date: "></asp:Label>
                <br />
                <asp:Label ID="DescriptionLabel" runat="server" Text="Description: "></asp:Label>
            </div>
            <div style="float: right; text-align: left; height: 150px; width: 500px; padding: 10px">
                <asp:TextBox ID="DateInput" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                <asp:TextBox ID="DescriptionTextBox" TextMode="multiline" Columns="10" Rows="5" runat="server" Height="100%" Width="100%"></asp:TextBox>
                <div style="float: left; width: 100%; padding-top: 5px">
                    <asp:Button ID="NewInfoButton" runat="server" Text="Add New Info" Style="float: left;" />
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" Style="float: right;" />
                </div>
            </div>
        </div>
        <div id="addedInfos"  style="float: left">
            <asp:Label ID="Label1" runat="server" Text="Label" BackColor="Black"></asp:Label>
        </div>
    </div>

</asp:Content>
