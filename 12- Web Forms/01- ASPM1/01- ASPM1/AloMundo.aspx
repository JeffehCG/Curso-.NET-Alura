<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AloMundo.aspx.cs" Inherits="_01__ASPM1.AloMundo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aló Mundo - Aula 1</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txMsg" runat="server"></asp:TextBox>
        <asp:Button ID="btExecutar" runat="server" OnClick="btExecutar_Click" style="height: 26px" Text="Executar" />
        <br />
        <asp:Label ID="lMsg" runat="server" Text="Esqueva o que deseja informar na caixa de texto"></asp:Label>
    </form>
</body>
</html>
