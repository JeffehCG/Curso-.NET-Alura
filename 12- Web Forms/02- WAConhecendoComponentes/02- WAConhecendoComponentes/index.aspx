<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_02__WAConhecendoComponentes.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/wfTabuada.aspx">Tabuada</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/wfParOuImparFatorial.aspx">Par Ou Impar</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/wfDiasDeVida.aspx">Dias de Vida</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/wfAlteraTamanhoFonte.aspx">Alterar Tamanho Fonte</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/wfBasicoJavascript.aspx">Javascript Basico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/wfComponentes1.aspx">Componentes 1</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/wfCursos.aspx">Cursos</asp:HyperLink>
                    </td>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/wfSitesParceiros.aspx">Sites Parceiros</asp:HyperLink>
                    </td>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/wfUpLoad.aspx">UpLoad de Arquivos</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/wfWizard.aspx">Wizard</asp:HyperLink>
                    </td>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/wfValidator.aspx">Validação</asp:HyperLink>
                    </td>
                    <td class="auto-style1">
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/wfMenu.aspx">Menu</asp:HyperLink>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
