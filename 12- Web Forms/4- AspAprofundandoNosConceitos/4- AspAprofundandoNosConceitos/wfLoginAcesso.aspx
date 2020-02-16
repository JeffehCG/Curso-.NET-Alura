<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfLoginAcesso.aspx.cs" Inherits="_4__AspAprofundandoNosConceitos.wfLoginAcesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="lbLogin" runat="server" Text=""></asp:Label>
            
            <br />
            <br />
            <asp:Button ID="btApagar" runat="server" Text="Apagar Cookies" OnClick="btLogout_Click" />
            
            <asp:Button ID="btListar" runat="server" Text="Listar Cookies" OnClick="btListar_Click" />
            
            <br />
            <br />
            <asp:Label ID="lbIdSession" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lbContador" runat="server" Text=""></asp:Label>
            
        &nbsp;<asp:Button ID="btAdicionarS" runat="server" Text="ADD" OnClick="btAdicionarS_Click" />
            <br />
            <asp:Button ID="btRemoverS" runat="server" Text="Remover" OnClick="btRemoverS_Click" />
            
            <br />
            <br />
            <asp:Label ID="lbContadorAplicacao" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btAdicionarAplic" runat="server" Text="ADD" OnClick="btAdicionarAplic_Click" />
            <asp:Button ID="btRemoverA" runat="server" Text="Remover" OnClick="btRemoverA_Click" />
            
        </div>
    </form>
</body>
</html>
