<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInfoPage.aspx.cs" Inherits="SupplyChain.ProductInfoPage" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 10px; padding: 10px;">
        <div style="float: left">

            <div style="float: left; text-align: right; padding: 10px">
                <asp:Label ID="IdLabel" runat="server" Text="ID: "></asp:Label>
                <br />
                <asp:Label ID="DateLabel" runat="server" Text="Date: "></asp:Label>
                <br />
                <asp:Label ID="DescriptionLabel" runat="server" Text="Description: "></asp:Label>
            </div>
            <div style="float: right; text-align: left; height: 150px; width: 500px; padding: 10px">
                <asp:TextBox ID="IdInput" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="DateInput" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                <asp:TextBox ID="DescriptionTextBox" TextMode="multiline" Columns="10" Rows="5" runat="server" Height="100%" Width="100%"></asp:TextBox>
                <div style="float: left; width: 100%; padding-top: 5px">
                    <asp:Button ID="NewInfoButton" OnClick="NewInfoButton_Click" runat="server" Text="Add New Info" Style="float: left;" />
                    <asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" runat="server" Text="Submit" Style="float: right;" />
                </div>
            </div>
        </div>
        <div id="addedInfos" style="float: left">
            <asp:Table ID="AddedInfosTable" GridLines="Both" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" CellPadding="15" CellSpacing="0" Runat="server">
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true">Date</asp:TableCell>
                    <asp:TableCell Font-Bold="true">Description</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
    </div>

</asp:Content>
