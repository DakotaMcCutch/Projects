<%@ Page Title="qsControl1" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="qsControl1.aspx.cs" Inherits="qsControl1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Pick Your Favorite Color</h2>
    <p><a href="qsControl2.aspx?favColor=blue">Blue</a></p>
    <p><a href="qsControl2.aspx?favColor=red">Red</a></p>
</asp:Content>

