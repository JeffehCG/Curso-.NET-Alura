<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfCursos.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfCursos" %>

<%@ Register src="~/UserControls/wucMenu.ascx" tagname="wucMenu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- Componente utilizado em varias paginas (wucMenu.ascx) --%>
            <uc1:wucMenu ID="wucMenu1" runat="server" />
            <%-- Propagandas --%>
            <%-- Esta sendo em cima de uma arquivo xml --%>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/XMLs/propragandas.xml" Target="_blank" />
            <br /> <br />
        </div>
        <div>

            <asp:Literal ID="Literal1" runat="server" Text="<h1>Teste Literal</h1><br/><p>Esse componente le o texto html etc... literalmente, e interpreta<p/>"></asp:Literal>

        </div>
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
                <asp:View ID="View1" runat="server">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/image1.jpg" OnClick="ImageButton1_Click" />
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="255px" ImageUrl="~/Images/image2.jpeg" OnClick="ImageButton2_Click" Width="404px" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Construct 2 - Do básico ao multiplayer" BorderStyle="None"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="O curso tem como objetivo ensinar de maneira pratica e dinamica os conceitos necessarios para se criar jogos na ferramenta Contruct 2"></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://udemy.com" Target="_blank">Compre o curso Construct 2 - Do básico ao multiplayer</asp:HyperLink>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="voltar_Click">Voltar</asp:LinkButton>
                </asp:View> 
                <asp:View ID="View3" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Construct 2 - Construindo um clone do jogo Timberman"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="O objetivo do curso é construir um jogo no estilo infinity runner baseado no game Timberman."></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLink2" runat="server">Compre o curso Construct 2 - Construindo um clone do jogo Timberman.</asp:HyperLink>
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="voltar_Click">Voltar</asp:LinkButton>
                    <br />
                </asp:View>              
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
