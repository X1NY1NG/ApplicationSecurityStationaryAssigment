<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="ApplicationSecurityStationaryAssigment.RegistrationForm"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<head runat="server">
    <script src="https://www.google.com/recaptcha/api.js?render=6LeEuRAaAAAAACge2ZqrBVQSkZHV9YguERDg33sB"></script>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 355px;
        }
        .progressing-20::-webkit-progress-value{
            background-color:red;
        }
        .progressing-20::-moz-progress-bar{
            background-color:red;
        }
        .auto-style3 {
            width: 355px;
            height: 33px;
        }
        .auto-style7 {
            margin-left: 0px;
        }
        .auto-style10 {
            width: 314px;
        }
        #strength{
            margin-top:-10px;
            margin-left:-520px;
        }
        .shifting{
            margin-left:280px;
            
        }
        .auto-style13 {
            width: 314px;
            height: 36px;
        }
        .auto-style14 {
            height: 36px;
        }
        .auto-style15 {
            margin-top: 0px;
        }
        .auto-style18 {
            width: 314px;
            height: 20px;
        }
        .auto-style19 {
            height: 20px;
        }
        .auto-style22 {
            width: 314px;
            height: 11px;
        }
        .auto-style23 {
            height: 11px;
        }
        .auto-style24 {
            width: 296px;
        }
        .auto-style25 {
            width: 296px;
            height: 36px;
        }
        .auto-style26 {
            width: 296px;
            height: 20px;
        }
        .auto-style27 {
            width: 296px;
            height: 11px;
        }
        .auto-style28 {
            width: 504px;
        }
        .auto-style29 {
            width: 504px;
            height: 36px;
        }
        .auto-style30 {
            width: 504px;
            height: 20px;
        }
        .auto-style31 {
            width: 504px;
            height: 11px;
        }
    </style>
    

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Registration "></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="lbname" runat="server" Text="First Name" Font-Bold="True"></asp:Label>
                        :</td>
                    <td class="auto-style28">
                        <asp:TextBox ID="tbfirstname" runat="server" Width="185px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="lblastname" runat="server" Text="Last Name" Font-Bold="True"></asp:Label>
                        :</td>
                    <td class="auto-style28">
                        <asp:TextBox ID="tblastname" runat="server" Width="181px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="lbemail" runat="server" Text="Email Address" Font-Bold="True"></asp:Label>
                        :</td>
                    <td class="auto-style28">
                        <asp:TextBox ID="tbemail" runat="server" TextMode="Email" Width="183px" onkeyup="javascript:myemailfunction(this.value)"></asp:TextBox><span id="emailvalidate"></span>
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Credit Card Details:"></asp:Label>
                        <br />
                    </td>
                    <td class="auto-style29">
                        </td>
                    <td class="auto-style13">
                        </td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <asp:Label ID="Label9" runat="server" Text="Name On Card:"></asp:Label>
                    </td>
                    <td class="auto-style29">
                        <asp:TextBox ID="tbnameoncard" runat="server"></asp:TextBox>
                        </td>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">
                        <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="Card Number:"></asp:Label>
                    </td>
                    <td class="auto-style30">
                        <asp:TextBox ID="tbcreditcardno" runat="server" CssClass="auto-style7" Width="180px" onkeyup="javascript:myvisafunction()" MaxLength="19"></asp:TextBox><span id="creditcardvalidate"></span>
                        </td>
                    <td class="auto-style18">
                        </td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style27">
                        <asp:Label ID="cvv" runat="server" Text="CVV:"  Font-Bold="False" ></asp:Label>
                    </td>
                    <td class="auto-style31">
                        <asp:TextBox ID="tbcvv" runat="server"  Width="80px" CssClass="auto-style15" MaxLength="4" onkeyup="javascript:mycvvfunction(this.value)" ></asp:TextBox><span id="cvvvalidate"></span>
                    </td>
                    <td class="auto-style22">
                        </td>
                    <td class="auto-style23"></td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="Label4" runat="server" Text="Expiry Date:" Font-Bold="True"></asp:Label>
                        <br />
                    </td>
                    <td class="auto-style28">
                        &nbsp;</td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="Label5" runat="server" Text="MM" ></asp:Label>
                        <asp:TextBox ID="tbmonth" runat="server" Width="64px"  MaxLength="2" onkeyup="javascript:mymonthfunction(this.value)"></asp:TextBox><span id="monthvalidate"></span>
                        
                        
                        <br />
                    </td>
                    <td class="auto-style28">
                        <asp:Label ID="Label6" runat="server" Text="YYYY"></asp:Label>
                        <asp:TextBox ID="tbyear" runat="server" Width="65px"  MaxLength="4" onkeyup="javascript:myyearfunction(this.value)"></asp:TextBox><span id="yearvalidate"></span></td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="lbbirthdate" runat="server" Text="Date Of Birth:" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style28">
                        <asp:TextBox ID="tbbirthdate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Label ID="lbpassword" runat="server" Text="Password:" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style28">
                        <asp:TextBox ID="tbpassword" runat="server" onkeyup="javascript:validate()" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="lbfeedback" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2"><progress max="100" value="0" id="strength" class="progressing" style='width:400px;height:50px;' runat="server" ></progress></td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                        <asp:Label ID="Label2" runat="server" CssClass="shifting"></asp:Label>
                        <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                    </td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" OnClientClick="return SomeMethod();" />
                    </td>
                    <td class="auto-style4" colspan="2"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
        <script type="text/javascript">
            document.getElementById('<%=tbemail.ClientID %>').value = "";
            document.getElementById('<%=tbcreditcardno.ClientID %>').value = "";
            document.getElementById('<%=tbcvv.ClientID %>').value = "";
            document.getElementById('<%=tbyear.ClientID %>').value = "";
            document.getElementById('<%=tbmonth.ClientID %>').value = "";
            

            var emailok = "false";
            var passwordok = "false";
            var monthok = "false";
            var yearok = "false";
            var creditcards = "false";
            var cvvok = "false";
           

            function validate() {
                passwordok = "false";
                var strengthBar = document.getElementById("strength")
                var strength = 0;
                var str = document.getElementById('<%=tbpassword.ClientID %>').value;

                if (str.length < 8) {

                    document.getElementById("lbfeedback").innerHTML = "Password Length Must be at least 8 Characters"
                    document.getElementById("lbfeedback").style.color = "Red";


                } else {
                    strength = strength + 1;
                }
                if (str.search(/[0-9]/) == -1) {

                    document.getElementById("lbfeedback").innerHTML = "Password require at least 1 number";
                    document.getElementById("lbfeedback").style.color = "Red";

                } else {
                    strength = strength + 1;
                }
                if (str.search(/[a-z]/) == -1) {

                    document.getElementById("lbfeedback").innerHTML = "Password require at least 1 LowerCase";
                    document.getElementById("lbfeedback").style.color = "Red";


                } else {
                    strength = strength + 1;
                }
                if (str.search(/[A-Z]/) == -1) {

                    document.getElementById("lbfeedback").innerHTML = "Password require at least 1 UpperCase";
                    document.getElementById("lbfeedback").style.color = "Red";

                } else {
                    strength = strength + 1;
                }
                if (str.search(/[^a-zA-Z0-9]/) == -1) {

                    document.getElementById("lbfeedback").innerHTML = "Password require at least 1 Special Character";
                    document.getElementById("lbfeedback").style.color = "Red";

                } else {
                    strength = strength + 1;
                }
                if (strength == 5) {

                    document.getElementById("lbfeedback").innerHTML = "Excellent!";
                    document.getElementById("lbfeedback").style.color = "Blue";
                    passwordok = "true";
                }

                switch (strength) {
                    case 0:
                        strengthBar.value = 0;



                        break
                    case 1:
                        strengthBar.value = 20;
                        document.getElementById("Label2").innerHTML = "Very Weak"


                        break
                    case 2:
                        strengthBar.value = 40;
                        document.getElementById("Label2").innerHTML = "Weak"

                        break
                    case 3:
                        strengthBar.value = 60;
                        document.getElementById("Label2").innerHTML = "Medium"

                        break
                    case 4:
                        strengthBar.value = 80;
                        document.getElementById("Label2").innerHTML = "Strong"

                        break
                    case 5:
                        strengthBar.value = 100;
                        document.getElementById("Label2").innerHTML = "Very Strong"


                        break

                }

            }

            function myvisafunction() {
                creditcards = "false";
                var oldchange = document.getElementById('<%=tbcreditcardno.ClientID %>').value;
            var newchange = oldchange;
            var beforechange = oldchange.split(" ").join("");

            var changing = beforechange.match(/.{1,4}/g);
            if (changing != null) {
                newchange = changing.join(" ");
            }

            document.getElementById('<%=tbcreditcardno.ClientID %>').value = newchange

                var visaRegEx = /^([4][0-9]{3}[\s][0-9]{4}[\s][0-9]{4}[\s][0-9]{1}|[4][0-9]{3}[\s][0-9]{4}[\s][0-9]{4}[\s][0-9]{4})$/;
                var masterRegEx = /^([5][0-9]{3}[\s][0-9]{4}[\s][0-9]{4}[\s][0-9]{4})$/;
                var amexRegEx = /^([3][47\t]{1}[0-9]{2}[\s][0-9]{4}[\s][0-9]{4}[\s][0-9]{3})$/;
                var discRegEx = /^([6][0-9]{3}[\s][0-9]{4}[\s][0-9]{4}[\s][0-9]{4})$/;
                if (visaRegEx.test(newchange)) {
                    document.getElementById("creditcardvalidate").innerHTML = "<i class='fa fa-cc-visa' style=' color:navy;font-size:20px;'></i>";
                    creditcards = "true";
                } else if (masterRegEx.test(newchange)) {
                    document.getElementById("creditcardvalidate").innerHTML = "<i class='fa fa-cc-mastercard' style='color:red;font-size:20px;'></i>";
                    creditcards = "true";
                } else if (amexRegEx.test(newchange)) {
                    document.getElementById("creditcardvalidate").innerHTML = "<i class='fa fa-cc-amex' style='  color:blue;font-size:20px;'></i>";
                    creditcards = "true";
                } else if (discRegEx.test(newchange)) {
                    document.getElementById("creditcardvalidate").innerHTML = "<i class='fa fa-cc-discover' style='color:orange;font-size:20px;'></i>";
                    creditcards = "true";
                } else {
                    document.getElementById("creditcardvalidate").innerHTML = "Invalid Credit Card";
                    document.getElementById("creditcardvalidate").style.color = "Invalid Credit Card";
                }
            }
            function mycvvfunction(doesthiswork) {
                cvvok = "false";
                var thevalue = doesthiswork;

                var thecvv = /^([0-9]{3,4})$/;
                if (thecvv.test(thevalue)) {
                    document.getElementById("cvvvalidate").innerHTML = "<i class='fa fa-check'></i>";
                    document.getElementById("cvvvalidate").style.color = "green";
                    cvvok = "true";
                }
            }
            function myyearfunction(theyears) {
                yearok = "false";
                var theyear = theyears;
                var theyearformat = /^([2][0][2][1-9])$/;
                if (theyearformat.test(theyear)) {
                    document.getElementById("yearvalidate").innerHTML = "<i class='fa fa-check'></i>";
                    document.getElementById("yearvalidate").style.color = "green";
                    yearok = "true";
                } else {
                    document.getElementById("yearvalidate").innerHTML = "Invalid Year"
                    document.getElementById("yearvalidate").style.color = "red";
                }
                if (document.getElementById("<%=tbmonth.ClientID %>") != null) {
                var themonthselected = document.getElementById("<%=tbmonth.ClientID %>").value;
                    mymonthfunction(themonthselected);
                }
            }
            function mymonthfunction(themonths) {
                monthok = "false";
                var thedate = new Date().getMonth();
                var theint = parseFloat(thedate) + 1;
                var theyear = new Date().getFullYear().toString();
                console.log(theyear);
                console.log(theint);
                var themonth = parseFloat(themonths);
                console.log(themonth);
                var themonthformat = /^([1-9]{1}|[1][012\t])$/;
                if (themonthformat.test(themonth)) {
                    if (document.getElementById("<%=tbyear.ClientID %>") != null) {
                    var theyearselected = document.getElementById("<%=tbyear.ClientID %>").value;
                        console.log(theyearselected);
                        if (theyearselected == theyear) {
                            if (themonth < theint) {
                                document.getElementById("monthvalidate").innerHTML = "Invalid Month"
                                document.getElementById("monthvalidate").style.color = "red";

                            } else {
                                document.getElementById("monthvalidate").innerHTML = "<i class='fa fa-check'></i>";
                                document.getElementById("monthvalidate").style.color = "green";
                                monthok = "true";

                            }
                        } else {
                            document.getElementById("monthvalidate").innerHTML = "<i class='fa fa-check'></i>";
                            document.getElementById("monthvalidate").style.color = "green";
                            monthok = "true";
                        }
                    }




                } else {
                    document.getElementById("monthvalidate").innerHTML = "Invalid Month"
                    document.getElementById("monthvalidate").style.color = "red";
                }
            }
            function myemailfunction(theemail) {
                emailok = "false";
                var theemailformat = /^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}|\d+)$/i;
                if (theemailformat.test(theemail)) {
                    document.getElementById("emailvalidate").innerHTML = "<i class='fa fa-check'></i>";
                    document.getElementById("emailvalidate").style.color = "green";
                    emailok = "true";

                } else {
                    document.getElementById("emailvalidate").innerHTML = "Invalid Email"
                    document.getElementById("emailvalidate").style.color = "red";

                }
            }
            
            function SomeMethod() {

                document.getElementById("<%=Label3.ClientID %>").innerHTML = "";

            if (document.getElementById("<%=tbfirstname.ClientID %>").value == "") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please fill up first name";
                return false;
            }
            if (document.getElementById("<%=tblastname.ClientID %>").value == "") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please fill up last name";
                return false;
            }
            if (document.getElementById("<%=tbbirthdate.ClientID %>").value == "") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please fill up birthdate";
                return false;
            }
            if (emailok == "false") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please enter email correctly";
                return false;
            }
            if (document.getElementById("<%=tbnameoncard.ClientID %>").value == "") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please fill up credit card name";
                return false;

            } else {
                var thenameformat = /^([A-Za-z]{1,50})$/;
                var thecredname = document.getElementById("<%=tbnameoncard.ClientID %>").value;
                if (thenameformat.test(thecredname)) {
                    

                } else {
                    document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please enter valid credit card name";
                    return false;
                }
            }
            if (creditcards == "false") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please enter Credit Card Number correctly";
                return false;
            }
            if (yearok == "false" || monthok=="false") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please enter Expiry Date correctly";
                return false;
            }

            if (cvvok == "false") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please enter CVV correctly";
                return false;
            }
            if (passwordok == "false") {
                document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please enter password correctly";
                return false;
            }
             
            if (document.getElementById('<%=tbpassword.ClientID %>').value != "") {
                var thepasswordformat = /([<>"/'#&]{1,100})$/;

                var thepassname = document.getElementById("<%=tbpassword.ClientID %>").value;
                if (thepasswordformat.test(thepassname)) {
                    document.getElementById("<%=Label3.ClientID %>").innerHTML = document.getElementById("<%=Label3.ClientID %>").innerHTML + "<br/> Please do not enter script tags";
                    return false;

                } else {
                    
                }
            } 
            if (document.getElementById("<%=tbfirstname.ClientID %>").value != "") {
                document.getElementById("<%=tbfirstname.ClientID %>").value = encodeHtml(document.getElementById("<%=tbfirstname.ClientID %>").value);
                
                
                if (document.getElementById("<%=tblastname.ClientID %>").value != "") {
                    document.getElementById("<%=tblastname.ClientID %>").value = encodeHtml(document.getElementById("<%=tblastname.ClientID %>").value);

                    if (document.getElementById("<%=tbbirthdate.ClientID %>").value != "") {
                        if (document.getElementById("<%=tbnameoncard.ClientID %>").value != "") {

                                if (emailok == "true" && passwordok == "true" && creditcards == "true" && cvvok == "true" && monthok == "true" && yearok == "true") {

                                } else {
                                    return false;
                                }
                        } else {
                                return false;
                        }



                        } else {

                            return false;

                        }

                    } else {

                        return false;
                    }

                } else {

                    return false;
                }


            }
            grecaptcha.ready(function () {
                grecaptcha.execute('6LeEuRAaAAAAACge2ZqrBVQSkZHV9YguERDg33sB', { action: 'login' }).then(function (token) {
                    document.getElementById("g-recaptcha-response").value = token;
                });
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
