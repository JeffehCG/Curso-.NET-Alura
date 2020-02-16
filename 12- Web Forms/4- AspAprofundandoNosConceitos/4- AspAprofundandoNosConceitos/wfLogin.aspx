<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="_4__AspAprofundandoNosConceitos.wfLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
                <br />
                <asp:TextBox ID="txbLogin" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
                <br />
                <asp:TextBox ID="txbSenha" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btEntrar" runat="server" Text="Entrar" OnClick="btEntrar_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
