<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verifyemail.aspx.cs" Inherits="ApplicationSecurityStationaryAssigment.verifyemail"  ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div hidden>
             <input type="hidden" id="helloworld" name="thevalue" value="" />
             <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
    <script>
        $(document).ready(function () {
            const urlParams = new URLSearchParams(window.location.search);
            const myParam = urlParams.get('param1');
            var newvalue = encodeHtml(myParam);
            console.log(newvalue);
            document.getElementById("helloworld").value = newvalue;
            document.getElementById("<%=Button1.ClientID %>").click();

            
        }); 
        function encodeHtml(unsafe) {
            return unsafe
                .replace(/&/g, "&#38;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#039;")
                .replace(/#/g, "&#35;");
        }

    </script>
</html>
