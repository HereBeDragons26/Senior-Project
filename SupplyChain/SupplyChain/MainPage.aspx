<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SupplyChain.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div >
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButtonClick" />
                <br />
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButtonClick" />
            </div>
        </div>
    </form>
</body>
</html>
