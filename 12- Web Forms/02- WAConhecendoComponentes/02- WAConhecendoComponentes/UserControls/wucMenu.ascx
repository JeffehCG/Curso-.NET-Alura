<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMenu.ascx.cs" Inherits="_02__WAConhecendoComponentes.wucMenu" %>

<%-- UserControls são arquivos que contem uma parte de codigo que sera utilizado em outras paginas, componentizando --%>
<asp:Menu ID="Menu1" runat="server" DataSourceID="Web">
</asp:Menu>
<asp:SiteMapDataSource ID="Web" runat="server" />

