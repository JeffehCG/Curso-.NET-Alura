<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfComponentes1.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfComponentes1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Conhecendo os componentes - parte 1</title>
    <style type="text/css">
        .auto-style1 {
            width: 300px;
        }
        .auto-style2 {
            width: 100%;
            height: 179px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style1">Site</td>
                    <td>Endereço</td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtSite" runat="server" Width="266px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndereco" runat="server" OnTextChanged="TextBox2_TextChanged" Width="225px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:ListBox ID="lbEndereco" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="273px" SelectionMode="Multiple">
                        </asp:ListBox>
                    </td>
                    <td>
                        <h3>Opções</h3>
                        <asp:Button ID="btInserir" runat="server" Text="Inserir" OnClick="btInserir_Click" />
                        <asp:Button ID="btSelecionar" runat="server" OnClick="btSelecionar_Click" Text="Selecionar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:DropDownList ID="dlSite" runat="server" style="margin-bottom: 0px" Height="79px" Width="269px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
