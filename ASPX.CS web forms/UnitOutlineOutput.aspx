<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitOutlineOutput.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><b>ACS Unit Outline Generator</b></h1>
            <br /><table id="tableContent" border="1" runat="server"></table>
        </div>
    </form>
    
   
    <iframe src ="../Hook's law lab report. Kip Minifie.pdf" width="100%" height="2000%"> <!-- change pdf to see if that fixes it -->
    </iframe>
    <p><br/>Click the button to print this page.</p>
    <button onclick="printFunction()">Print</button>

    <script>
      function printFunction() {
        window.print();
      }
    </script>
</body>
</html>
