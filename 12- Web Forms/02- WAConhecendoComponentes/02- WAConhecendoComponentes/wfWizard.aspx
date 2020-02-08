<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfWizard.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfWizard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 822px;
            height: 370px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" Height="367px" Width="819px" OnFinishButtonClick="Wizard1_FinishButtonClick">
                <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
                <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
                <StepStyle Font-Size="0.8em" ForeColor="#333333" />
                <WizardSteps>
                    <asp:WizardStep runat="server" title="Dados Basicos">
                        <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbnome" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="CPF"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbCpf" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="RG"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbRg" runat="server"></asp:TextBox>
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" title="Endereço">
                        <asp:Label ID="Label4" runat="server" Text="CEP"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbCep" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbEstado" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Cidade"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbCidade" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Rua"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbRua" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Bairro"></asp:Label>
                        <br />
                        <asp:TextBox ID="txbBairro" runat="server"></asp:TextBox>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
        </div>
    </form>
</body>
</html>
