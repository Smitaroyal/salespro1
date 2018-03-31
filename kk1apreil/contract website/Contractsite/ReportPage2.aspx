<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportPage2.aspx.cs" Inherits="Contractsite_ReportPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="para">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        Date<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
       <!-- Date<br />
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <br /-->
        Office<br />
        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
        <br />
        Venue<br />
        <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>
        <div id="page">


            <rsweb:ReportViewer ID="ReportViewer2" runat="server" Height="600px" Width="916px">
            </rsweb:ReportViewer>


        </div>
    </div>
    </form>
</body>
</html>
