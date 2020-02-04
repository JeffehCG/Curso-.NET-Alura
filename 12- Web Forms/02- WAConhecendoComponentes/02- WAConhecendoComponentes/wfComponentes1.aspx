<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfComponentes1.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfComponentes1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Conhecendo os componentes - parte 1</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>Site</td>
                    <td>Endereço</td>
                    <td>Opções</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSite" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndereco" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btInserir" runat="server" Text="Inserir" OnClick="btInserir_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="dlSite" runat="server" style="margin-bottom: 0px">
                            <asp:ListItem Value="1">make inde games</asp:ListItem>
                            <asp:ListItem Value="2">war games</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
