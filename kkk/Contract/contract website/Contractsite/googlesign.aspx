<%@ Page Language="C#" AutoEventWireup="true" CodeFile="googlesign.aspx.cs" Inherits="Contractsite_googlesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="google-signin-client_id" content="636149411195-gl8ilq9gs8ahc2jreb58tuu5d5u4k7ut.apps.googleusercontent.com">
    <script src="https://apis.google.com/js/platform.js" async defer></script>
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>

        function SI()
        {
            alert('hi');
            var profile = googleUser.getBasicProfile();
            var email = profile.getEmail();

            alert(profile + '  ' + email);
        }



        function topFunction2() {
            //alert('hi');

            window.location.href = "~/WebSite5/production/login.aspx";
            return false;

        }

        function pele(kk) {
            alert(kk);
            // window.location.href("Dashboard.aspx");
            //topFunction2();
            return false;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" name="b1" id="b1" value="sign in" onclick="SI();" />
        <asp:Button ID="Button1" runat="server" Text="ok" OnClick="Button1_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
