<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SearchEngine.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 81px">

            <asp:TextBox ID="UrlText" runat="server" Width="194px"></asp:TextBox>
&nbsp;URL<br />
            <br />
            <asp:TextBox ID="KeyText" runat="server" Width="193px"></asp:TextBox>
&nbsp;Anahtar Kelime<br />
            <br />
            <asp:Button ID="SearchButton" runat="server" Text="Ara" OnClick="SearchButton_Click" />

        </div>
    </form>
</body>
</html>
