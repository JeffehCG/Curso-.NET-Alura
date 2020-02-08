<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfAlteraTamanhoFonte.aspx.cs" Inherits="_02__WAConhecendoComponentes.wfAlteraTamanhoFonte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var tamanho = 12;
        function IncText() {
            tamanho = tamanho + 1;
            document.getElementById("p1").style.fontSize = tamanho + "px";
            document.getElementById("p2").style.fontSize = tamanho + "px";
        }
        function DecText() {
            tamanho = tamanho - 1;
            document.getElementById("p1").style.fontSize = tamanho + "px";
            document.getElementById("p2").style.fontSize = tamanho + "px";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:HyperLink ID="HyperLink1" runat="server" onClick="IncText()">Aumentar Fonte +</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" onClick="DecText()">Diminuir Fonte -</asp:HyperLink>
            
        </div>
    </form>
    <p id="p1" style="font-size:12px">Exemplo de como alterar o tamanho da fonte de um paragrafo</p>
    <p id="p2" style="font-size:12px">Alo Mundo!!!</p>
</body>
</html>
