<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login Page.aspx.cs" Inherits="Contractsite_Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 177px;
        }
        .auto-style2 {
            width: 177px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <center>

    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
         <asp:Image ID="Image1" runat="server" Height="444px" ImageUrl="~/Contractsite/KarmaGroup_logo_FA.jpg" Width="797px" ImageAlign="Middle" />
        <br />

                    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                &nbsp;
                    <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
                <br />
        <br />

                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                &nbsp;
                    <asp:TextBox ID="pswdTextBox" runat="server" TextMode="Password"></asp:TextBox>
                <br />
        <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                <br />
        <br />
    
    </div>
    </form>
        
    </center>
</body>
</html>
