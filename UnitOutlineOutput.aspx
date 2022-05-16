﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitOutlineOutput.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACS Unit Outline Generator</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><b>Unit Outline</b></h1>
            <div contenteditable="true"> <!-- makes the unit outline editable by the user -->
            <br /><table id="tableContent" border="1" runat="server"></table>
            </div>
        </div>
    </form>
    
   
    <iframe src ="../Hook's law lab report. Kip Minifie.pdf" width="100%" height="20000%" sandbox="allow-scripts"> <!-- change pdf to see if that fixes it -->
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