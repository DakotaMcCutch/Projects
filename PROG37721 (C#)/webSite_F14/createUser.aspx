<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createUser.aspx.cs" Inherits="createUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        UserName:<div>
    
            <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
            <br />
            <br />
            Password<br />
            <asp:TextBox ID="txtPWord" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="cmdWrite" runat="server" Text="Create User" />
    
    </div>
    </form>
</body>
</html>
