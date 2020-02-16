<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfFilmes.aspx.cs" Inherits="_4__AspAprofundandoNosConceitos.wfFilmes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Filmes: Insira um novo filme"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlFilmes" runat="server">
            </asp:DropDownList>
            <asp:TextBox ID="txbFilme" runat="server" ToolTip="Digite o nome de um filme"></asp:TextBox>
            <asp:Button ID="btInserir" runat="server" Text="Inserir" OnClick="btInserir_Click" />
            <br />
            <%-- PostBackUrl - Enviando dados de uma pagina para outra via Post --%>
            <asp:Button ID="btEnviar" runat="server" Text="Enviar" OnClick="btEnviar_Click" PostBackUrl="~/wfFilmesResposta.aspx"/>
        </div>
    </form>
</body>
</html>
