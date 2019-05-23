<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyResult.aspx.cs" Inherits="SupplyChain.VerifyResult" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="margin-top: 5px" > 

        <asp:Table ID="VerifyResultTable" GridLines="Both" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" CellPadding="15" CellSpacing="0" Runat="server" BorderStyle="Outset" BorderColor="Gray" BorderWidth="5px"  > 
            <asp:TableRow >
                <asp:TableCell Font-Bold="true" >Date</asp:TableCell>
                <asp:TableCell Font-Bold="true">Description</asp:TableCell>
            </asp:TableRow>
        </asp:Table>  

    </div>
      
</asp:Content>