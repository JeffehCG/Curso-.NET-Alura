<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfParOuImparFatorial.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfParOuImparFatorial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:BulletedList ID="blLista" runat="server" BulletStyle="Circle" DisplayMode="LinkButton" OnClick="blLista_Click">
            </asp:BulletedList>
            <br />
            <asp:Panel ID="pnParOuImpar" runat="server" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="Verificar se o numero é par ou impar"></asp:Label>
                <br />
                <asp:TextBox ID="txtValorPn1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Verificar" OnClick="Button1_Click" />
                <br />
                <asp:Label ID="lResp1" runat="server" Text="Informe um numero!"></asp:Label>

            </asp:Panel>
            <br />
            <asp:Panel ID="pnFatorial" runat="server" Visible="False">
                <asp:Label ID="Label2" runat="server" Text="Calcular o fatorial"></asp:Label>
                <br />
                <asp:TextBox ID="txtValorPn2" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Calcular" OnClick="Button2_Click" style="height: 26px" />
                <br />
                <asp:Label ID="lResp2" runat="server" Text="Informe um numero!"></asp:Label>
            </asp:Panel>
        </div>
        <asp:Panel ID="pnRadioButton" runat="server">
            <%-- Para que apenas um radio button fique selecionado é preciso utilizar o GroupName --%>
            <asp:Label ID="Label3" runat="server" Text="Radio Button"></asp:Label>
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Par ou Impar" GroupName="radio" Checked="true"/>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="radio" Text="Calcular Fatorial" />
        </asp:Panel>
        <asp:Panel ID="pnRadioButtonList" runat="server">
            <asp:Label ID="Label4" runat="server" Text="Radio Button List"></asp:Label>
            <br />
            <asp:RadioButtonList ID="radioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radioButtonList_SelectedIndexChanged" >
            </asp:RadioButtonList>
        </asp:Panel>
    </form>
</body>
</html>
