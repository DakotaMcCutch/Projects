<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dataTest3.aspx.cs" Inherits="dataTest3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            color: #00FF00;
            background-color: #000000;
        }
        html {
            background-color: black;
            color: greenyellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" BackColor="Black" BorderColor="Yellow" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">

            <FooterStyle BackColor="Black" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="GreenYellow" />
            <PagerStyle BackColor="Black" ForeColor="GreenYellow" HorizontalAlign="Left" />
            <RowStyle BackColor="Black" ForeColor="GreenYellow"/>
            <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Orange" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
