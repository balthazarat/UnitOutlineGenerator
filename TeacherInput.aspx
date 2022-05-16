<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherInput.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name<asp:TextBox ID="txtName" runat="server"></asp:TextBox> 
        <br />
        </div>
        <p>
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="Insert Data" />  
        </p>
        <p>
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Class search
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
    </form>
</body>
</html>
