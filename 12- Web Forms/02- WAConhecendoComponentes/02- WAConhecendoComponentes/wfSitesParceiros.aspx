<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfSitesParceiros.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfSitesParceiros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- Com imageMap você pode definir varias areas clicaveis na imagem --%>
            <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/Images/image3.jpg">
                <asp:RectangleHotSpot AlternateText="Site Google" Bottom="400" NavigateUrl="www.google.com" Right="400" Target="_blank" />
                <asp:RectangleHotSpot AlternateText="Twitter" Left="100" NavigateUrl="twitter.com.br" Target="_blank" Top="100" />
            </asp:ImageMap>
        </div>
    </form>
</body>
</html>
