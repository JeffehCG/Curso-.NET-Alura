<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfMenu.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <Items>
                    <asp:MenuItem NavigateUrl="~/wfCursos.aspx" Text="Cadastros" Value="Cadastros">
                        <asp:MenuItem ImageUrl="~/Images/image3.jpg" Text="Cliente" Value="Cliente"></asp:MenuItem>
                        <asp:MenuItem Text="Fornecedores" Value="Fornecedores"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Consultas" Value="Consultas"></asp:MenuItem>
                    <asp:MenuItem Text="Relatorios" Value="Relatorios"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
        </div>
    </form>
</body>
</html>
