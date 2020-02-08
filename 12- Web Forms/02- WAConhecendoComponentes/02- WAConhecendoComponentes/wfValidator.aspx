<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfValidator.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#66CCFF" GroupingText="Validação de campos" Height="372px" Width="825px">
                <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
                <asp:TextBox ID="txbNome" runat="server"></asp:TextBox>
                <%-- Componente de validação (Required), (ControlToValidate="txbNome") deve ser associado ao componente que sera validado --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbNome" ErrorMessage="Campo Obrigatorio!"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label5" runat="server" Text="E-mail: "></asp:Label>
                <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
                <%-- Componente de validação (Pode ser definido expressões regulares para fazer a validação (Regex)) --%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbEmail" ErrorMessage="Informe o e-mail corretamente!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Idade: "></asp:Label>
                <asp:TextBox ID="txbIdade" runat="server"></asp:TextBox>
                <%-- Componente de validação () --%>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Valor fora do escopo permitido!" MaximumValue="100" MinimumValue="1" ControlToValidate="txbIdade" Type="Integer"></asp:RangeValidator>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Senha: "></asp:Label>
                <asp:TextBox ID="txbSenha" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbSenha" ErrorMessage="Digite a Senha!"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Confirmar Senha: "></asp:Label>
                <asp:TextBox ID="txbConfSenha" runat="server" TextMode="Password"></asp:TextBox>
                <%-- Componente de validação (Comparação), (ControlToCompare="txbSenha") componente que sera comparado com o associado--%>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbSenha" ControlToValidate="txbConfSenha" ErrorMessage="Senhas informadas não são iguais"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbConfSenha" ErrorMessage="Digite a confirmação de senha!"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btEnviar" runat="server" Text="Enviar" OnClick="btEnviar_Click" />
                <%-- Exibe a lista de erros de validação --%>
                <%-- ShowMessageBox="True" - Exibe a lista em um alert --%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                <br />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>

<%-- Para que o Validator funcione de forma adequada é preciso colocar o codigo abaixo no Web.config --%><%-- <appSettings>
    <add key="ValidationSettings:UnobtrusiveValidationMode" value="None"/>
  </appSettings> --%>
