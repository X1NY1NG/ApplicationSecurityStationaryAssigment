<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="ApplicationSecurityStationaryAssigment.Loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://www.google.com/recaptcha/api.js?render=6LeEuRAaAAAAACge2ZqrBVQSkZHV9YguERDg33sB"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
            <br />
            <asp:Label ID="lbemail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbemail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbpassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbpassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lbfeedback" runat="server"></asp:Label>
            <br />
            <asp:Button ID="submitbutton" runat="server" OnClick="submitbutton_Click" Text="submit" />
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
        </div>
    </form>
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LeEuRAaAAAAACge2ZqrBVQSkZHV9YguERDg33sB', { action: 'login' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
    </script>
</body>
</html>
