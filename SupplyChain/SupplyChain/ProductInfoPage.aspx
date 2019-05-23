<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInfoPage.aspx.cs" Inherits="SupplyChain.ProductInfoPage" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 10px; padding: 10px;">
        <div style="float: left">

            <div style="float: left; text-align: right; padding-top : 20px;  ">
                <asp:Label ID="ProductParentIdLabel" AssociatedControlID="ProductParentIdInput" runat="server" Text="Parent ID: " Font-Names="Bookman" Font-Bold="true"  Font-Italic="true" >
               </asp:Label>
                <br />
                <asp:Label ID="DateLabel" runat="server" Text="Date: " AssociatedControlID="DateInput" Font-Names="Bookman" Font-Bold="true"  Font-Italic="true" ></asp:Label>
                <br />
                <asp:Label ID="DescriptionLabel" runat="server" Text="Description: " AssociatedControlID="DescriptionTextBox" Font-Names="Bookman" Font-Bold="true"  Font-Italic="true"></asp:Label>
            </div>
            <div style="float: right; text-align: left; height: 150px; width: 500px; padding: 10px">
                <asp:TextBox ID="ProductParentIdInput" runat="server" BorderStyle="Inset" BorderColor="#85C1E9" BorderWidth="6px"></asp:TextBox>
                &nbsp;<asp:Button ID="AddParentId" OnClick="AddParentId_Click" runat="server" Text="Add Parent ID" BackColor="#85C1E9" BorderStyle="Dotted" />
                <br />
                
                <asp:TextBox ID="DateInput" runat="server" TextMode="Date" BorderStyle="Inset" BorderColor="#85C1E9" BorderWidth="6px"></asp:TextBox>
                &nbsp;<br />
                <asp:TextBox ID="DescriptionTextBox" TextMode="multiline" Columns="10" Rows="5" runat="server" Height="100%" Width="100%" BorderStyle="Inset" BorderColor="#85C1E9" BorderWidth="6px"></asp:TextBox>
                <div style="float: left; width: 100%; padding-top: 5px">
                    <asp:Button ID="NewInfoButton" OnClick="NewInfoButton_Click" runat="server" Text="Add New Info" Style="float: left;" BackColor="#85C1E9" BorderStyle="Dotted"/>
                    <asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" runat="server" Text="Submit" Style="float: right;" BackColor="#85C1E9" BorderStyle="Dotted"/>
                </div>
            </div>
        </div>
        <div id="addedInfos" style="float: left">
            <asp:Table ID="AddedInfosTable" GridLines="Both" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" CellPadding="15" CellSpacing="0" Runat="server" BorderStyle="Groove" BorderColor="#85C1E9" BorderWidth="6px">
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true">Date</asp:TableCell>
                    <asp:TableCell Font-Bold="true">Description</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
        <div id="addedParents" style="float: left">
            <asp:Table ID="AddedParentsTable" GridLines="Both" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" CellPadding="15" CellSpacing="0" Runat="server"  BorderStyle="Groove" BorderColor="#85C1E9" BorderWidth="6px">
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true">ParentId</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
    </div>

</asp:Content>
