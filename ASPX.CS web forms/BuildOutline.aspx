<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildOutline.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br /><table id="tableContent" border="1" runat="server"></table>
            <asp:Button ID="Button1" runat="server" Text="Unit Outline 1" onclick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Unit Outline 3" onclick="Button2_Click"/>
        </div>
    </form>
</body>
</html>
