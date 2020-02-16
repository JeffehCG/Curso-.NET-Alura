<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfSalarioMinimo.aspx.cs" Inherits="_4__AspAprofundandoNosConceitos.wfSalarioMinimo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Informe o salario bruto"></asp:Label>
            <br />
            <asp:TextBox ID="txbSalarioBruto" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Percentual de desconto"></asp:Label>
            <br />
            <%-- AutoPostBack="true" - necessario para o evento SelectedIndexChanged funcionar --%>
            <asp:RadioButtonList ID="rbPerDesconto" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Selected="True" Value="10">10%</asp:ListItem>
                <asp:ListItem Value="20">20%</asp:ListItem>
                <asp:ListItem Value="30">30%</asp:ListItem>
                <asp:ListItem>Outro</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="txbPercentual" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />

            <%-- PostBackUrl= para que Pagina que sera redirecionada, e enviado os dados via POST ao acionar o botão --%>
            <asp:Button ID="btEnviar" runat="server" Text="Enviar Dados" PostBackUrl="~/wfSalarioMinimoResposta.aspx?nome=Jefferson Costa" />
        </div>
    </form>
</body>
</html>
