﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="successpage.aspx.cs" Inherits="ApplicationSecurityStationaryAssigment.successpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="changepassword" runat="server" OnClick="changepassword_Click" Text="Change Password" />
            <br />
            <br />
            <asp:Button ID="logoutbutton" runat="server" OnClick="logoutbutton_Click" Text="Logout" />
        </div>
    </form>
</body>
</html>
