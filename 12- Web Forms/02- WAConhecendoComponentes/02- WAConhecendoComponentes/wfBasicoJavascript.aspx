<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfBasicoJavascript.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfBasicoJavascript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function ExibeMensagem() {
            alert('Alô Mundo!!!!!')
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/image1.jpg" onMouseOver="ExibeMensagem()"/>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Clique no Botão" />
        </div>
    </form>
</body>
</html>
