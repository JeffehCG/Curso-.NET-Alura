<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMenu.ascx.cs" Inherits="_02__WAConhecendoComponentes.wucMenu" %>

<%-- Esse menu sera utilizado em outras paginas --%>
<asp:Menu ID="Menu1" runat="server" DataSourceID="Web">
</asp:Menu>
<asp:SiteMapDataSource ID="Web" runat="server" />

