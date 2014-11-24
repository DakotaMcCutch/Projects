<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default</title>
    <style type="text/css">
        .newStyle1 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }
    </style>
</head>
<body style="height: 297px">
    <form id="form1" runat="server">
    <div>
    
        Enter Your Name:</div>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="cmdHello" runat="server" OnClick="cmdHello_Click" Text="Hello" />
        </p>
        <asp:Label ID="lblHello" runat="server"></asp:Label>
    </form>
</body>
</html>
