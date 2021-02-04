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
            <asp:Button ID="submitbutton" runat="server" OnClick="submitbutton_Click" Text="submit" OnClientClick="return SomeMethod();" />
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
            <br />
            <asp:Label ID="robottext" runat="server"></asp:Label>
        </div>
    </form>
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LeEuRAaAAAAACge2ZqrBVQSkZHV9YguERDg33sB', { action: 'login' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });

        function SomeMethod() {
            
            if (document.getElementById("<%=tbemail.ClientID %>").value != "" ) {
                var theemailformat = /^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}|\d+)$/i;
                var theemail = document.getElementById("<%=tbemail.ClientID %>").value;
                if (theemailformat.test(theemail)) {

                } else {
                    document.getElementById("<%=lbfeedback.ClientID %>").innerHTML = "Invalid Email Address format";
                    return false;
                }
            } else {
                document.getElementById("<%=lbfeedback.ClientID %>").innerHTML = "Please Enter Email";
                return false;
            }
            if (document.getElementById("<%=tbpassword.ClientID %>").value != "") {
                var thepasswordformat = /((?=.*?["<>'&#]).{1,})$/;
                var thepassname = document.getElementById("<%=tbpassword.ClientID %>").value;
                if (thepasswordformat.test(thepassname)) {
                    document.getElementById("<%=lbfeedback.ClientID %>").innerHTML = "Invalid Password format";
                    return false;
                } else {
                    

                }

            } else {
                document.getElementById("<%=lbfeedback.ClientID %>").innerHTML = "Please Enter Password";
                return false;
            }




            
           


        }
        
        
    </script>
</body>
</html>
