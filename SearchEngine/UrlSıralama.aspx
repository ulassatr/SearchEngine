<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrlSıralama.aspx.cs" Inherits="SearchEngine.UrlSıralama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 240px">
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="UrlText" runat="server" Width="179px"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="KelimeText" runat="server" Width="181px"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Button ID="btn_urlEkle" runat="server" Text="Url Ekle" OnClick="btn_urlEkle_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="button_kelimeEkle" runat="server" Text="Kelime Ekle" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btn_UrlSırala" runat="server" Text="Sırala" OnClick="btn_UrlSırala_Click" />
        </div>
    </form>
    
</body>
</html>
