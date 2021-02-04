<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="ApplicationSecurityStationaryAssigment.changepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Enter Current Password:"></asp:Label>
            <asp:TextBox ID="currentpassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="New Password:"></asp:Label>
            <asp:TextBox ID="newpassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" OnClientClick="return SomeMethod();" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
    <script>
        function SomeMethod() {
            if (document.getElementById("<%=currentpassword.ClientID %>").value != "") {
                var thepasswordformat = /((?=.*?["<>'&#]).{1,})$/;
                var thepassname = document.getElementById("<%=currentpassword.ClientID %>").value;
                if (thepasswordformat.test(thepassname)) {
                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Invalid Password format";
                    return false;
                } else {
                    
                }

            } else {
                document.getElementById("<%=Label2.ClientID %>").innerHTML = "Please Enter Current Password";
                return false;
            }

            if (document.getElementById("<%=newpassword.ClientID %>").value != "") {
                var str = document.getElementById('<%=newpassword.ClientID %>').value;

                if (str.length < 8) {

                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Password Length Must be at least 8 Characters"
                    return false;


                } 
                if (str.search(/[0-9]/) == -1) {

                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Password require at least 1 number";
                    return false;
                }
                if (str.search(/[a-z]/) == -1) {

                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Password require at least 1 LowerCase";
                    return false;
                } 
                if (str.search(/[A-Z]/) == -1) {

                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Password require at least 1 UpperCase";
                    return false;

                }
                if (str.search(/[^a-zA-Z0-9]/) == -1) {

                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Password require at least 1 Special Character";
                    return false;

                } 
                var thepasswordformats = /((?=.*?["<>'&#]).{1,})$/;
                var thepassnames = document.getElementById("<%=newpassword.ClientID %>").value;
                if (thepasswordformats.test(thepassnames)) {
                    document.getElementById("<%=Label2.ClientID %>").innerHTML = "Invalid Password format";
                    return false;
                } else {
                    
                }

            } else {
                document.getElementById("<%=Label2.ClientID %>").innerHTML = "Please Enter New Password";
                return false;
            }

        }
    </script>
</html>
