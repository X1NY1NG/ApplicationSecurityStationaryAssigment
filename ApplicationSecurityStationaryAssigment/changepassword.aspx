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
            <asp:TextBox ID="currentpassword" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="New Password:"></asp:Label>
            <asp:TextBox ID="newpassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" OnClientClick="return SomeMethod();" />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
    <script>
        function SomeMethod() {
            if (document.getElementById("<%=currentpassword.ClientID %>").value != "") {
                var thepasswordformat = /([<>"/'#&]{1,100})$/;
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
                var thepasswordformats = /([<>"/'#&]{1,100})$/;
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
