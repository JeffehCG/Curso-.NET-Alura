<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="_3__WaAgenda.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="E-mail"></asp:Label>
            <br />
            <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
            <br />
            <asp:TextBox ID="txbSenha" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btLogar" runat="server" Text="Logar" OnClick="btLogar_Click" />
            <br />
            <br />
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
