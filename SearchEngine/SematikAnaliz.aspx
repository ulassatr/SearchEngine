<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SematikAnaliz.aspx.cs" Inherits="SearchEngine.SematikAnaliz" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 354px">
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="594px"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:TextBox ID="TextBox2" runat="server" Width="592px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="102px" />
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"  ReadOnly="True" TextMode="MultiLine" Width="586px"></asp:TextBox>
    </form>
</body>
</html>

