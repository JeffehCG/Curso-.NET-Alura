<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfUpLoad.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfUpLoad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="UpLoad de Arquivos"></asp:Label>
            <br />
            <br />
            <%-- AllowMultiple="True" - permitindo mais de um arquivo de uma vez --%>
            <asp:FileUpload ID="fuArquivo" runat="server" AllowMultiple="True" Width="595px" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nome do Arquivo: "></asp:Label>
            <asp:TextBox ID="txbNome" runat="server" Width="472px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Tamanho do Arquivo: "></asp:Label>
            <asp:TextBox ID="txbTamanho" runat="server" Width="454px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btEnviar" runat="server" OnClick="btEnviar_Click" Text="Enviar Arquivo" Width="217px" />
            <asp:Button ID="btEnviarMultiplos" runat="server" Text="Enviar Multiplos Arquivo" Width="217px" OnClick="btEnviarMultiplos_Click" />
            <br />
        </div>
    </form>
</body>
</html>
