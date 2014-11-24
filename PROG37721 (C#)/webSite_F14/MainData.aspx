<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainData.aspx.cs" Inherits="MainData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        table {
            text-align: center;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Main Data Page</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Click Here to <a href="Insert.aspx">insert a row</a> in users Table
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UsersConnectionString %>" SelectCommand="SELECT * FROM [tUsers]"></asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                            <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Update Row" ShowHeader="True" Text="update" />
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="delete" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
